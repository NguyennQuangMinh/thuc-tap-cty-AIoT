#include "main.h"
#include "C:\hoc\8051\bai_tap\Library\Delay\Delay.h"

sbit LSA = P2^2;
sbit LSB = P2^3;
sbit LSC = P2^4;

unsigned char code DIG_CODE[16]={ 0x3f,0x06,0x5b,0x4f,0x66,0x6d,0x7d,0x07,
																	0x7f,0x6f,0x77,0x7c,0x39,0x5e,0x79,0x71}; // ma led 7 thanh tu 0->9 va tu A->F

void main()
{
	// hien thi ra 8 con led so tu 0->7
	unsigned char i;
	while(1)
	{
		for(i=0; i<8; i++) // quet led 7 doan
		{
			switch(i)
			{
				case(0):
					LSA = 0; LSB = 0; LSC = 0; break;
				case(1):
					LSA = 1; LSB = 0; LSC = 0; break;
				case(2):
					LSA = 0; LSB = 1; LSC = 0; break;
				case(3):
					LSA = 1; LSB = 1; LSC = 0; break;
				case(4):
					LSA = 0; LSB = 0; LSC = 1; break;
				case(5):
					LSA = 1; LSB = 0; LSC = 1; break;
				case(6):
					LSA = 0; LSB = 1; LSC = 1; break;
				case(7):
					LSA = 1; LSB = 1; LSC = 1; break;
			}
			P0 = DIG_CODE[i];
			Delay_ms(1);
			P0 = 0x00;
		}
	}
}
