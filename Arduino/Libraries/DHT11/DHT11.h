
#ifndef DHT11_h
#define DHT11_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

extern "C" {
	typedef void(*humiditySensorCallbackFunction) (const uint16_t cid, const int16_t value);
}

class DHT11 {

	public:

		DHT11();
		void init(uint16_t p_cid, uint16_t p_pin, uint32_t p_interval, humiditySensorCallbackFunction p_callback);
		void reset();

		boolean inited;
		uint16_t cid;
		uint16_t pin;
		uint32_t interval;

		void changePin(uint16_t p_pin);
		void changeInterval(uint32_t p_interval);
		void update();
		
	private:
		
		byte _result[5];
		uint16_t _humidity;
		boolean _ready;
		boolean _wait;
		uint32_t _tready;			// DHT11 sensors need warmup of approximately 1s
		uint32_t _twait;			// wait for at least 18ms to trigger sensor each run
		uint32_t _time;				// interval for sending data back to main program
		void beginRead();
		void endRead();
		byte readByteFromBus();
		humiditySensorCallbackFunction _callback;

};

#endif
