
#include "PCA9685.h"
#include <Wire.h>

PCA9685::PCA9685() {
	inited = false;
}

void PCA9685::init(uint16_t p_cid, uint16_t p_pin, uint16_t p_board, uint16_t p_min, uint16_t p_max, uint16_t p_time, uint16_t p_interval, float p_position) {
	if(!inited) {
		cid = p_cid;
		pin = p_pin;
		board = p_board;
		min = p_min;
		max = p_max;
		time = p_time;
		interval = p_interval;
		position = p_position;
		// init servo library
		begin(board);
		setPwmFrequency(board, 1000/interval);
		// set initial angle
		write(position);
		// activate servo
		inited = true;
	}
}

void PCA9685::change(uint16_t p_pin, uint16_t p_board) {
	if(inited) {
		// cache arguments to local fields
		pin = p_pin;
		board = p_board;
		// init servo library
		reset(board);
		begin(board);
		setPwmFrequency(board, 1000/interval);
	}
}

void PCA9685::reset() {
	if(inited) {
		reset(board);
		inited = false;
	}
}

void PCA9685::update(uint16_t p_min, uint16_t p_max, uint16_t p_time) {
	if(inited) {
		min = p_min;
		max = p_max;
		time = p_time;
	}
}

void PCA9685::write(float p_position) {
	if (inited) {
		position = p_position;
		float minf = (float)min;
		float maxf = (float)max;
		position_us = (short)((maxf-minf)/100.0*position+minf);
		setPwm(board, pin, 0, position_us);
	}
}

void PCA9685::writeMicro(uint16_t p_value) {
	position_us = p_value;
	setPwm(board, pin, 0, p_value);
}

/* sets the next target position: position = [min, max] °; tgoal = time available to reach next goal */
void PCA9685::target(float p_position, uint32_t p_time) {
	if (inited) {
		_tposition = p_position;
		float distance = absf(_tposition - position);
		_direction = sgnf(_tposition - position);
		float f_time = (float)p_time;
		float f_interval = (float)interval;
		float steps = f_time/f_interval;
		_speed = distance / steps;
		completed = false;
	}
}

void PCA9685::updateTargeting() {
	if (inited && !completed) {
		// calculate pwm value
		if(_direction > 0) {
			if (position < _tposition) {
				position += _speed;
			} else {
				position = _tposition;
				completed = true;
			}
		} else {
			if (position > _tposition) {
				position -= _speed;
			} else {
				position = _tposition;
				completed = true;
			}
		}
		// set pwm value
		write(position);
	}
}

/* ******************************** */
/* PCA9685 pwm extension functions  */
/* ******************************** */

void PCA9685::begin(uint8_t addr) {
	Wire.begin();
	reset(addr);
}

void PCA9685::reset(uint8_t addr) {
	write8(addr, PCA9685_MODE1, 0x0);
}

void PCA9685::setPwm(uint8_t addr, uint8_t num, uint16_t on, uint16_t off) {
	Wire.beginTransmission(addr);
	Wire.write(LED0_ON_L + 4 * num);
	Wire.write(on);
	Wire.write(on >> 8);
	Wire.write(off);
	Wire.write(off >> 8);
	Wire.endTransmission();
}

/* sets pin without having to deal with on/off tick placement and properly handles
/* a zero value as completely off.  Optional invert parameter supports inverting
/* the pulse for sinking to ground.  Val should be a value from 0 to 4095 inclusive. */
void PCA9685::setPin(uint8_t addr, uint8_t num, uint16_t val, bool invert) {
	// clamp value between 0 and 4095 inclusive.
	val = min(val, 4095);
	if (invert) {
		if (val == 0) {
			// special value for signal fully on.
			setPwm(addr, num, 4096, 0);
		} else if (val == 4095) {
			// special value for signal fully off.
			setPwm(addr, num, 0, 4096);
		} else {
			setPwm(addr, num, 0, 4095 - val);
		}
	} else {
		if (val == 4095) {
			// special value for signal fully on.
			setPwm(addr, num, 4096, 0);
		} else if (val == 0) {
			// special value for signal fully off.
			setPwm(addr, num, 0, 4096);
		} else {
			setPwm(addr, num, 0, val);
		}
	}
}

void PCA9685::setPwmFrequency(uint8_t addr, float freq) {
	freq *= 0.9;												// correct for overshoot in the frequency setting (see issue #11).
	float prescaleval = 25000000;
	prescaleval /= 4096;
	prescaleval /= freq;
	prescaleval -= 1;
	uint8_t prescale = floor(prescaleval + 0.5);
	uint8_t oldmode = read8(addr, PCA9685_MODE1);
	uint8_t newmode = (oldmode & 0x7F) | 0x10;					// sleep
	write8(addr, PCA9685_MODE1, newmode);						// go to sleep
	write8(addr, PCA9685_PRESCALE, prescale);					// set the prescaler
	write8(addr, PCA9685_MODE1, oldmode);
	delay(5);
	write8(addr, PCA9685_MODE1, oldmode | 0xa1);				// this sets the MODE1 register to turn on auto increment.
}

uint8_t PCA9685::read8(uint8_t addr, uint8_t reg) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.endTransmission();
	Wire.requestFrom((uint8_t)addr, (uint8_t)1);
	return Wire.read();
}

void PCA9685::write8(uint8_t addr, uint8_t reg, uint8_t data) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.write(data);
	Wire.endTransmission();
}