#include "main.h"
#include "C:\hoc\8051\bai_tap\Library\Delay\Delay.h"

sbit LSA=P2^2;
sbit LSB=P2^3;
sbit LSC=P2^4;

unsigned char code DIG_CODE[10]={0x3f,0x06,0x5b,0x4f,0x66,0x6d,0x7d,0x07,0x7f,0x6f}; //ma led 7 thanh cathode tu 0 -> 9

// moi giay tang bien dem len 1 lan hien thi len led 7 thanh tu 00-20

void main()
{
	unsigned int i;
	unsigned int cnt = 0;
	unsigned int chuc, donvi;
	while(1)
	{
		for(i=0; i<460; i++)
		{
			// quet led hien thi so
			chuc = cnt/10;
			donvi = cnt%10;
			
			//hien thi led 7 thanh o hang don vi
			LSA = 0; LSB = 0; LSC = 0; 
			P0 = DIG_CODE[donvi];
			Delay_ms(1);
			P0 = 0x00;
			
			//hien thi led 7 thanh o hang chuc
			LSA = 1; LSB = 0; LSC = 0; 
			P0 = DIG_CODE[chuc];
			Delay_ms(1);
			P0 = 0x00;
		}

		cnt++;//tang bien dem len
		if(cnt>=100){//dem den 100 thi reset ve 0
			cnt = 0;
		}
		
		//cach kiem tra xem co dung 1 giay tang 1 lan hay khong, cach nay khong hay cho lam
		if(cnt!=0)
		{
			P1_0 = !P1_0;
		}
	}
}
