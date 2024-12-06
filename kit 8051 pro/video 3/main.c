// nhan k1 thi se nhap nhay led
// nhan k2 thi se nhap nhay led xen ke
// nhan k3 chop tat 4 led, 4 led duoi
// nhan k4 se tat toan bo cac hieu ung

#include "main.h"
#include "C:\hoc\8051\bai_tap\Library\Delay\Delay.h"

#define led P2

sbit K1 = P3^1;
sbit K2 = P3^0;
sbit K3 = P3^2;
sbit K4 = P3^3;

bit pressFlag = 0;

unsigned int checkPress()
{
	unsigned int i;
	for(i=0; i<50; i++)
	{
		Delay_ms(10);
		if(K1==0 || K2 == 0 || K3 == 0 || K4==0)
		{
			if(pressFlag==0)
			{
				pressFlag = 1;
				return 1;
			}
		}else pressFlag = 0;
	}
	return 0;
}

void main()
{
	unsigned char cnt=0;
	while(1)
	{
		// che do 1
		if(K1==0)
		{
			Delay_ms(20); // chong doi phim
			while(K1 == 0); // doi cho nguoi dung nha phim ra
			led = 0xFF;
			while(1)
			{
				if(checkPress()) break;
				led = ~led;
			}
		}
		//che do 2
			if(K2==0)
			{
				Delay_ms(20); // chong doi phim
				while(K2 == 0); // doi cho nguoi dung nha phim ra
				led = 0x55;
				while(1)
				{
					if(checkPress()) break;
					led = ~led;
				}
			}
			//che do 3
			if(K3==0)
			{
				Delay_ms(20); // chong doi phim
				while(K3 == 0); // doi cho nguoi dung nha phim ra
				led = 0xF0;
				while(1)
				{
					if(checkPress()) break;
					led = ~led;
				}
			}
			//che do 4
			if(K4==0)
			{
				Delay_ms(20); // chong doi phim
				while(K4 == 0); // doi cho nguoi dung nha phim ra
				led = 0xFF;
				while(1)
				{
					if(checkPress()) break;
				}
			}
		}
}

