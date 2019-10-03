
#include "MPU6500.h"
#include <Wire.h>

MPU6500::MPU6500() {
	inited = false;
}

void MPU6500::init(uint16_t p_cid, uint8_t p_addr, uint32_t p_interval, gyroscopeSensorCallbackFunction p_callback) {
	if(!inited) {
		cid = p_cid;
		addr = p_addr;
		_interval = p_interval;
		_callback = p_callback;
		// initialize i2c bus
		Wire.begin();
		// configure accelerometer
		write(p_addr, 28, ACCELEROMETER_SCALE);
		// configure gyroscope
		write(p_addr, 27, GYROSCOPE_SCALE);
		// reset start time
		_time = millis();
		// flag as running instance
		inited = true;
	}
}

void MPU6500::reset() {
	inited = false;
}

void MPU6500::changeInterval(uint32_t p_interval) {
	if(inited) {
		_interval = p_interval;
	}
}

void MPU6500::read() {
	if(inited) {
		MPU6500_Result result;
		uint8_t buffer[14];
		read(addr, 0x3B, 14, buffer);
		// parse resultfer from accelerometer
		result.ax = -(buffer[0] << 8 | buffer[1]);
		result.ay = -(buffer[2] << 8 | buffer[3]);
		result.az = buffer[4] << 8 | buffer[5];
		// parse resultfer from gyroscope
		result.gx = -(buffer[8] << 8 | buffer[9]);
		result.gy = -(buffer[10] << 8 | buffer[11]);
		result.gz = buffer[12] << 8 | buffer[13];
		// callback attached function
		if(_callback != NULL) {
			(*_callback)(cid, result);
		}
	}
}

void MPU6500::read(uint8_t addr, uint8_t reg, uint8_t nbytes, uint8_t* data) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.endTransmission();
	Wire.requestFrom(addr, nbytes);
	uint8_t index = 0;
	while(Wire.available()) {
		data[index++] = Wire.read();
	}
}

void MPU6500::write(uint8_t addr, uint8_t reg, uint8_t data) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.write(data);
	Wire.endTransmission();
}

void MPU6500::update() {
	if(inited) {
		if(millis() - _time >= _interval) {
			read();
			_time = millis();
		}
	}
}