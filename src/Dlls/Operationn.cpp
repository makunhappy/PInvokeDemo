#include "pch.h"
#include "Operationn.h"
#include<Windows.h>
#include<string>
#include<iostream>
using namespace std;


int sum(int a, int b)
{
	return a + b;
}
//∂‡Ã¨
int sum(int a, int b, int c)
{
	return a + b + c;
}
DWORD WINAPI  loopthread(LPVOID para);
HANDLE thread;
DWORD threadId;
void test(void* callBack)
{
	thread = CreateThread(nullptr, 0, loopthread, callBack, 0, &threadId);
}
DWORD WINAPI  loopthread(LPVOID para)
{
	//void* func(char* p);
	int i = 0;
	auto pf = reinterpret_cast<void (*)(int)>(para);
	while (true)
	{
		i++;
		Sleep(1000);
		pf(i);
		if (i > 40)
		{
			break;
		}
	}
	return 0;
}
void testenum(Day day, char* v)
{
	if (day == Sunday)
	{
		sprintf(v, "sunday");
	}
	else if (day == Monday)
	{
		sprintf(v, "Monday");
	}
}
void testsimplestruct(Persion p, char* res)
{
	sprintf(res, "%s,%d,%d", p.name, p.age, p.score);
}
void testptrstruct(People* p)
{
	p->persion = new Persion();
	char tmp[] = "name";
	p->persion->name = new char[strlen(tmp) + 1];
	strcpy(p->persion->name, tmp);
	p->persion->age = 18;
	p->persion->score = 100;
	p->count = 1;
}

#pragma region global variable
int num;
void SetVariable(int i)
{
	num = i;
}
int GetVariable()
{
	return num;
}
#pragma endregion
