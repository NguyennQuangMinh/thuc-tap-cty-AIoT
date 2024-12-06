#include <REGX52.H>
#include "C:\AIOT\kit 8051 pro\MyLib\Delay_ms\Delay.h"

void main()
{
	unsigned char i;
	while(1)
	{
		// chop tat led o port 2
		for(i=0; i<10; i++)
		{
			P2 = ~P2;
			Delay_ms(500);		
		}
		
		// sang dan tung led
		for(i=0; i<8; i++)	
		{
			P2 <<= 1;
			P2 &= 0xFE;
			Delay_ms(500);
		}
		// tat dan tung led
		for(i =0 ; i<8 ;i++)
		{
			P2 >>= 1;
			P2 |= 0x80;
			Delay_ms(500);
		}
//		0000 0000
//		1000 0000
//		1000 0000
//		
//		0100 0000
//		1000 0000
//		1100 0000
//		
//		0110 0000
//		1000 0000
//		
//		1110 0000
	}
}
