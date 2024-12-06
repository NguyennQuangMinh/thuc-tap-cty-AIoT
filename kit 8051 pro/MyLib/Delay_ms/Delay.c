#include "Delay.h"
#include "main.h"

// su dung Delay voi thach anh 12Mhz
#if (FREQ_OSC == 12000000)
	void Delay_ms(unsigned int t)
	{
		unsigned int x, y;
		for(x=0; x<t; x++)
		{
			for(y=0; y<123; y++);
		}
	}

// su dung Delay voi thach anh 11.0592Mhz
#elif (FREQ_OSC == 11059200)
	void Delay_ms(unsigned int t)
	{
		unsigned int x, y;
		for(x=0; x<t; x++)
		{
			for(y=0; y<113; y++);
		}
	}

//su dung Delay voi thach anh 8Mhz
#elif (FREQ_OSC == 8000000)
	void Delay_ms(unsigned int t)
	{
		unsigned int x, y;
		for(x=0; x<t; x++)
		{
			for(y=0; y<218; y++);
		}
	}

//su dung Delay voi thach anh 4Mhz
#elif (FREQ_OSC == 4000000)
	void Delay_ms(unsigned int t)
	{
		unsigned int x, y;
		for(x=0; x<t; x++)
		{
			for(y=0; y<106; y++);
		}
	}

#else
	#error "Khong co ham Delay_ms voi tan so tuong ung"
	
#endif