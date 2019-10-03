
#ifndef LED_h
#define LED_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
#endif

#define YELLOW   39
#define ORANGE   41
#define RED      43
#define GREEN    45
#define BLUE     47

class LED {

	public:
		LED();
		void blink(short pin, long interval);
		void stop(short pin);
		void on(short pin);
		void off(short pin);
		void reset();
		void update();
		
	private:
		bool _ready;
		bool _state[5];
		long _interval[5];
		unsigned long _next[5];
		unsigned long _ctime;
		short p2i(short pin);
		short i2p(short index);
		
};

#endif
