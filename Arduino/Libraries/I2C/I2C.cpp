
#include "I2C.h"
#include <Wire.h>

I2C::I2C() {
	Wire.begin();
}

void I2C::scan(uint8_t* devices, size_t& size) {

	/* The i2c_scanner uses the return value of
	/* the Write.endTransmisstion to see if
	/* a device did acknowledge to the address. */
	uint8_t result, address;
	uint16_t index = 0;

	for(address=1; address<127; address++) {
		Wire.beginTransmission(address);
		result = Wire.endTransmission();
		if(result == 0) {
			if(index<size) {
				if(address<16) {
					devices[index] = 0;
				} else {
					devices[index] = address;
				}
				index++;
			}
		}
	}

	return devices;

}

void I2C::read(uint8_t addr, uint8_t reg, uint8_t nbytes, uint8_t* data) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.endTransmission();
	Wire.requestFrom(addr, nbytes);
	uint8_t index = 0;
	while(Wire.available()) {
		data[index++] = Wire.read();
	}
}

void I2C::write(uint8_t addr, uint8_t reg, uint8_t data) {
	Wire.beginTransmission(addr);
	Wire.write(reg);
	Wire.write(data);
	Wire.endTransmission();
}