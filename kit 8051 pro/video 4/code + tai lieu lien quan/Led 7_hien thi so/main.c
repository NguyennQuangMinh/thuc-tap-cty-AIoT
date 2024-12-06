
#include<reg51.h>

#define GPIO_DIG P0

sbit LSA=P2^2;
sbit LSB=P2^3;
sbit LSC=P2^4;

unsigned char code DIG_CODE[10]={0x3f,0x06,0x5b,0x4f,0x66,0x6d,0x7d,0x07,0x7f,0x6f}; //ma led 7 thanh cathode tu 0 -> 9

void main(void)
{
	LSA=0;
	LSB=0;
	LSC=0;
	while(1)
	{
		GPIO_DIG=DIG_CODE[9];
	}				
}