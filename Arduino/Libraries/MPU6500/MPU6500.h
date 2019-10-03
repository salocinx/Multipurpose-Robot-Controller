#ifndef MPU6500_h
#define MPU6500_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

#define GYROSCOPE_SCALE             0x18      // 2000_DPS = 0x18; 1000_DPS = 0x10; 500_DPS = 0x08; 250_DPS = 0x00
#define ACCELEROMETER_SCALE         0x18      // 16_G = 0x18; 8_G = 0x10; 4_G = 0x08; 2_G = 0x00

typedef struct {
	int16_t ax;
	int16_t ay;
	int16_t az;
	int16_t gx;
	int16_t gy;
	int16_t gz;
} MPU6500_Result;

extern "C" {
	typedef void(*gyroscopeSensorCallbackFunction) (const uint16_t cid, const MPU6500_Result result);
}

class MPU6500 {

	public:
		MPU6500();
		void init(uint16_t p_cid, uint8_t p_addr, uint32_t p_interval, gyroscopeSensorCallbackFunction p_callback);
		void changeInterval(uint32_t p_interval);
		void reset();
		void read();
		void update();
		bool inited;
		uint16_t cid;								// component id
		uint8_t addr;								// i2c bus address

	private:
		uint32_t _time;
		uint32_t _interval;
		void read(uint8_t addr, uint8_t reg, uint8_t nbytes, uint8_t* data);
		void write(uint8_t addr, uint8_t reg, uint8_t data);
		gyroscopeSensorCallbackFunction _callback;

};

#endif