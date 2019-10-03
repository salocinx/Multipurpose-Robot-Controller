#include "Analog.h"

Analog::Analog() {
	inited = false;
}

void Analog::init(uint16_t p_cid, uint16_t p_pin, uint32_t p_interval, analogSensorCallbackFunction p_callback) {
	if(!inited) {
		cid = p_cid;
		pin = p_pin;
		_interval = p_interval;
		_callback = p_callback;
		_time = millis();
		inited = true;
	}
}

void Analog::reset() {
	inited = false;
}

void Analog::changePin(uint16_t p_pin) {
	if(inited) {
		pin = p_pin;
	}
}

void Analog::changeInterval(uint32_t p_interval) {
	if(inited) {
		_interval = p_interval;
	}
}

void Analog::read() {
	if(inited) {
		// read sensor value
		uint16_t value = analogRead(pin);
		// callback attached function
		if(_callback != NULL) {
			(*_callback)(cid, value);
		}
	}
}

void Analog::update() {
	if(inited) {
		if(millis() - _time >= _interval) {
			read();
			_time = millis();
		}
	}
}