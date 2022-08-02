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
//¶àÌ¬
int sum(int a, int b, int c)
{
	return a + b + c;
}
DWORD WINAPI  loopthread(LPVOID para);
HANDLE thread;
DWORD threadId;
void test(void* callBack)
{
	cout << callBack << endl;
	//thread = CreateThread(nullptr, 0, loopthread, callBack, 0, &threadId);
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
void testcallback(void* callBack)
{
	auto pf = reinterpret_cast<void (*)(LogInfo)>(callBack);
	LogInfo* logInfo = new LogInfo();
	sprintf(logInfo->logs[0].data, "hello");
	sprintf(logInfo->logs[1].data, "world");
	logInfo->count = 2;
	pf(*logInfo);
	//std::cout << "finish" << endl;
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
void testsimplestructwithclass(Persion1* p)
{
	//sprintf(p->name, "hehe");
	std::cout << p->name << endl;
	p->age = 18;
	p->score = 100;
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

#pragma region ·µ»ØÄÚ´æ¿é

int TestBuf(void** p)
{
	int cnt = 10;
	int* data = new int[10];
	for (size_t i = 0; i < cnt; i++)
	{
		data[i] = i;
	}
	printf("0x%p\n", data);
	*p = data;
	printf("0x%p\n", *p);
	return 0;
}
int FreeBuf(void* p)
{
	delete p;
	return 0;
}
#pragma endregion

int InputCharStar(char* arr)
{
	cout << arr << endl;
	return 0;
}
int TestArray(int arr[], int count)
{
	cout << sizeof(arr) << endl;
	cout << sizeof(arr[0]) << endl;
	for (size_t i = 0; i < count; i++)
	{
		std::cout << arr[i] << "\t";
	}
	return 0;
}
