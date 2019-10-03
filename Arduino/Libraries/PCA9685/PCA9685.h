
/* DESCRIPTION:

   This library lets you control servos attached to a i2c
   controlled PCA9685 with 16 PWM channels each featuring
   a resolution of 12 bits [0, 4096).
   Moreover, the library handles controlling servos over
   time. This means, that you can send a target position
   and the time it will take to reach this target position.
   Positions are always handled in percents of [min, max], but
   the servos need to be initialized with their 'min' and 
   'max' values measured in [us]. The angle is then mapped
   to the corresponding microsecond value which is forwareded
   to the corresponding board. The board field determines the
   controller type {i2c addresses: 0x40-0x43}.
   Typically, the PCA9685 controlled servos operate somewhere 
   between 150us and 600us.
*/

#ifndef PCA9685_h
#define PCA9685_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

// PCA9685 i2c pwm extension definitions

#define PCA9685_SUBADR1		0x2
#define PCA9685_SUBADR2		0x3
#define PCA9685_SUBADR3		0x4

#define PCA9685_MODE1		0x0
#define PCA9685_PRESCALE	0xFE

#define LED0_ON_L			0x6
#define LED0_ON_H			0x7
#define LED0_OFF_L			0x8
#define LED0_OFF_H			0x9

#define ALLLED_ON_L			0xFA
#define ALLLED_ON_H			0xFB
#define ALLLED_OFF_L		0xFC
#define ALLLED_OFF_H		0xFD

class PCA9685 {

	public:

		PCA9685();

		bool inited = false;
		bool completed = true;
		float position = 0.0;						// current position in percents of min and max [0, 100] -> [min, max]
		uint16_t cid;								// component id
		uint16_t pin = 0;							// giop pin servo is attached to
		uint16_t board = 0x20;						// servo controller (arduino=0x20, adafruit=[0x40, 0x43])
		uint16_t min = 150;							// min position in [us]
		uint16_t max = 600;							// max position in [us]
		uint16_t time = 400;						// time in ms for a full turning angle at 100% speed
		uint16_t interval = 10;						// interval at which servos targeting is clocked
		uint16_t position_us = 0;					// current position in microseconds

		void init(uint16_t p_cid, uint16_t p_pin, uint16_t p_board, uint16_t p_min, uint16_t p_max, uint16_t p_time, uint16_t p_interval, float p_position);
		void change(uint16_t p_pin, uint16_t p_board);
		void reset();
		void update(uint16_t p_min, uint16_t p_max, uint16_t p_time);
		void write(float p_position);
		void writeMicro(uint16_t p_value);
		void target(float p_position, uint32_t p_time);
		void updateTargeting();

	private:

		/* servo movement info */
		int8_t _direction = 0;						// servo movement direction {-1, +1}
		float _tposition = 0.0;						// target position in percents of min and max [0, 100] -> [min, max]
		float _speed = 0.0;							// position change each cycle measured in [us]
		/* i2c servo pwm extension */
		void begin(uint8_t addr);
		void reset(uint8_t addr);
		void setPwm(uint8_t addr, uint8_t num, uint16_t on, uint16_t off);
		void setPin(uint8_t addr, uint8_t num, uint16_t val, bool invert = false);
		void setPwmFrequency(uint8_t addr, float freq);
		uint8_t read8(uint8_t addr, uint8_t reg);
		void write8(uint8_t addr, uint8_t reg, uint8_t data);


	/* toolkit functions */
	static inline int8_t sgn(short val) {
		if (val < 0) return -1;
		if (val == 0) return 0;
		return 1;
	}

	static inline int8_t sgnf(float val) {
		if (val < 0.0) return -1;
		if (val == 0.0) return 0;
		return 1;
	}

	static inline float absf(float val) {
		if (val > 0.0) {
			return val;
		} else if (val < 0.0) {
			return val*-1.0;
		} else {
			return 0.0;
		}
	}

};

#endif