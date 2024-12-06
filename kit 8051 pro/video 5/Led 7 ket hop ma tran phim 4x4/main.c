#include "main.h"
#include "C:\hoc\8051\bai_tap\Library\Delay\Delay.h"

// khai bao chan ket noi cua ic 74hc138
sbit LSA=P2^2;
sbit LSB=P2^3;
sbit LSC=P2^4;

// khai bao chan ket noi cua key pad
sbit COL_1 = P1^0;
sbit COL_2 = P1^1;
sbit COL_3 = P1^2;
sbit COL_4 = P1^3;

sbit ROW_1 = P1^4;
sbit ROW_2 = P1^5;
sbit ROW_3 = P1^6;
sbit ROW_4 = P1^7;

unsigned char code DIG_CODE[16] = {
    0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07,
    0x7f, 0x6f, 0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71
}; // ma led 7 doan tu 0->9 và tu A->F

char DisplayData[8]; // mang tao du lieu cua 8 led 7 doan

void DigDisplay()
{
	unsigned char i;
	for(i = 0; i < 8; i++)
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
		//quet led
		P0 = DisplayData[i];
		Delay_ms(1);
		P0 = 0x00;
	}
}

unsigned char KeyPress()
{
 	unsigned char key = 0xFF;  // khoi tao 1 gia tri khong hop le de kiem tra
	
	// Kiem tra hang 4
	ROW_4 = 0;
	if(COL_4 == 0) key = 0;
	if(COL_3 == 0) key = 1;
	if(COL_2 == 0) key = 2;
	if(COL_1 == 0) key = 3;
	ROW_4 = 1;

	// Kiem tra hang 3
	ROW_3 = 0;
	if(COL_4 == 0) key = 7;
	if(COL_3 == 0) key = 6;
	if(COL_2 == 0) key = 5;
	if(COL_1 == 0) key = 4;
	ROW_3 = 1;

	// Kiem tra hang 4
	ROW_2 = 0;
	if(COL_4 == 0) key = 8;
	if(COL_3 == 0) key = 9;
	if(COL_2 == 0) key = 10;
	if(COL_1 == 0) key = 11;
	ROW_2 = 1;

	// Kiem tra hang 4
	ROW_1 = 0;
	if(COL_4 == 0) key = 15;
	if(COL_3 == 0) key = 14;
	if(COL_2 == 0) key = 13;
	if(COL_1 == 0) key = 12;
	ROW_1 = 1;
	
	return key;	
}

void main()
{
	unsigned char key, keyState = 0, lastKey = 0xFF;
	while(1)
	{
		key = KeyPress();

		// Kiem tra xem phím có duoc nhan và nha không lan dau tien
		if(key != 0xFF && lastKey == 0xFF)
		{
			keyState = 1;  // Ðánh dau phím dã duoc nhan
		}
		else if(key == 0xFF && lastKey != 0xFF)
		{
			keyState = 0;  // Ðánh dau rang phím dã duoc nha
			// Cap nhat so sau khi phím dã nha
			DisplayData[7] = DisplayData[6];
			DisplayData[6] = DisplayData[5];
			DisplayData[5] = DisplayData[4];
			DisplayData[4] = DisplayData[3];
			DisplayData[3] = DisplayData[2];
			DisplayData[2] = DisplayData[1];
			DisplayData[1] = DisplayData[0];
			DisplayData[0] = DIG_CODE[lastKey];
		}
		lastKey = key; // Cap nhat trang thái phím cuoi cùng
		DigDisplay(); // hien thi du lieu lên màn hình
	}
}
	