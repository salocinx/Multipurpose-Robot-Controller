#ifndef I2C_h
#define I2C_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

class I2C {

	public:
		I2C();
		void scan(uint8_t* devices, size_t& size);
		void read(uint8_t addr, uint8_t reg, uint8_t nbytes, uint8_t* data);
		void write(uint8_t addr, uint8_t reg, uint8_t data);

};

#endif