#include "DHT11.h"

DHT11::DHT11() {
	inited = false;
}

void DHT11::init(uint16_t p_cid, uint16_t p_pin, uint32_t p_interval, humiditySensorCallbackFunction p_callback) {
	if(!inited) {
		cid = p_cid;
		pin = p_pin;
		interval = p_interval;
		_callback = p_callback;
		_time = millis();
		pinMode(pin, OUTPUT);		// set serial read-in pin to output
		digitalWrite(pin, HIGH);	// the bus is waiting as long as the pin is high
		_tready = millis();
		_ready = false;
		_wait = false;
		inited = true;
	}
}

void DHT11::reset() {
	_ready = false;
	_wait = false;
	inited = false;
}

void DHT11::changePin(uint16_t p_pin) {
	if(inited) {
		pin = p_pin;
	}
}

void DHT11::changeInterval(uint32_t p_interval) {
	if(inited) {
		interval = p_interval;
	}
}

void DHT11::beginRead() {
	if(inited && _ready) {
		digitalWrite(pin, LOW);									    // send start signal by setting the bus to low for the next >= 18ms
		_twait = micros();
		_wait = true;
	}
}

void DHT11::endRead() {
	if (inited && _ready) {

		digitalWrite(pin, HIGH);									// the results should arrive 20-40us after the line is pulled-up again
		delayMicroseconds(40);

		pinMode(pin, INPUT);										// change the pin direction, since DHT11 will now send 40bit of data
		while (digitalRead(pin) == HIGH);
		delayMicroseconds(80);										// DHT11 replies by pulling the bus high for 80us ...
		if (digitalRead(pin) == LOW);
		delayMicroseconds(80);										// ... and then low for another 80us, data transmission begins

		for(uint8_t i=0; i<4; i++) {								// receive temperature and humidity data 4b data + 1b checksum
			_result[i] = readByteFromBus();
		}

		_humidity = (uint16_t)(_result[0] + (_result[1]/256.0));
		//_temperature = _result[2] + (_result[3]/256.0);

		pinMode(pin, OUTPUT);										// signal bus to wait until next measurement is taken
		digitalWrite(pin, HIGH);

		if (_callback != NULL) {
			(*_callback)(cid, _humidity);							// callback read function with measured values
		}

		_wait = false;

	}
}

byte DHT11::readByteFromBus() {
	byte data;
	for(uint8_t i=0; i<8; i++) {
		if(digitalRead(pin) == LOW) {
			while (digitalRead(pin) == LOW);						// wait for 50us
			delayMicroseconds(30);									// determine the duration of the high level to determine the data is 0 or 1
			if(digitalRead(pin) == HIGH) {
				data |= (1 << (7 - i));								// high front and low in the post
			}
			while (digitalRead(pin) == HIGH);						// data is 1, wait for the next bit to be received
		}
	}
	return data;
}

void DHT11::update() {
	if(inited) {
		// asynchronoulsy wait for DHT11 to get ready
		if(!_ready) {
			if(millis() - _tready >= 2000) {
				_ready = true;
			}
		}
		// asynchronoulsy wait for DHT11 to prepare
		if(_ready && _wait) {
			if(micros() - _twait >= 32000 || micros() - _twait <= 0) {
				endRead();
			}
		}
		if(_ready && !_wait) {
			// send sensor value to main program
			if(millis() - _time >= interval) {
				// read sensor value asynchronously
				beginRead();
				// reset timer for next read process
				_time = millis();
			}
		}
	}
}