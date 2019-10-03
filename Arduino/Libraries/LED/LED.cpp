#include "LED.h"

LED::LED() {
	reset();
}

void LED::blink(short pin, long interval) {
	if(_interval[p2i(pin)]==-1) {
		short index = p2i(pin);
		_interval[index] = interval;
		_next[index] = millis()+_interval[index];
		_ready = true;
	}
}

void LED::stop(short pin) {
	if(_interval[p2i(pin)]>=0) {
		off(pin);
		// don't process update if no LED is blinking
		for(uint8_t i=0; i<5; i++) {
			if(_interval[i]>0) {
				return;
			}
		}
		_ready = false;
	}
}

void LED::on(short pin) {
	short index = p2i(pin);
	_interval[index] = -1;
	_state[index] = true;
	digitalWrite(pin, HIGH);
}

void LED::off(short pin) {
	short index = p2i(pin);
	_interval[index] = -1;
	_state[index] = false;
	digitalWrite(pin, LOW);
}

void LED::reset() {
	for(uint8_t i=0; i<5; i++) {
		short pin = i2p(i);
		_interval[i] = -1;
		pinMode(pin, OUTPUT);
		digitalWrite(pin, LOW);
	}
	_ready = false;
}

void LED::update() {
	if(_ready) {
		_ctime = millis();
		for(uint8_t i=0; i<5; i++) {
			if(_interval[i]>0) {
				if(_ctime>=_next[i]) {
					_state[i] = !_state[i];
					if(_state[i]) {
						digitalWrite(i2p(i), HIGH);
					} else {
						digitalWrite(i2p(i), LOW);
					}
					_next[i] = _ctime+_interval[i];
				}
			}
		}
	}
}

short LED::p2i(short pin) {
	if(pin==YELLOW) {
		return 0;
	} else if(pin==ORANGE) {
		return 1;
	} else if(pin==RED) {
		return 2;
	} else if(pin==GREEN) {
		return 3;
	} else if(pin==BLUE) {
		return 4;
	}
}

short LED::i2p(short index) {
	if(index==0) {
		return YELLOW;
	} else if(index==1) {
		return ORANGE;
	} else if(index==2) {
		return RED;
	} else if(index==3) {
		return GREEN;
	} else if(index==4) {
		return BLUE;
	}
}