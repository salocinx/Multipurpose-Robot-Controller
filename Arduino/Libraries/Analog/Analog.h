
#ifndef Analog_h
#define Analog_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

extern "C" {
	typedef void(*analogSensorCallbackFunction) (const uint16_t cid, const int16_t value);
}

class Analog {

	public:

		Analog();
		void init(uint16_t p_cid, uint16_t p_pin, uint32_t p_interval, analogSensorCallbackFunction p_callback);
		
		boolean inited;
		uint16_t cid;
		uint16_t pin;

		void changePin(uint16_t p_pin);
		void changeInterval(uint32_t p_interval);
		void reset();
		void read();
		void update();
		
	private:

		uint32_t _time;
		uint32_t _interval;
		analogSensorCallbackFunction _callback;
		
};

#endif
