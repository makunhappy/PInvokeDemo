#pragma once

enum Day
{
	Sunday,
	Monday,
};

struct Persion
{
	char* name;
	int age;
	int score;
};
struct People
{
	struct Persion* persion;
	int count;

};
extern "C" _declspec(dllexport) int sum(int, int);
extern "C" _declspec(dllexport) void test(void* callBack);
extern "C" _declspec(dllexport) void testenum(Day day, char* v);
extern "C" _declspec(dllexport) void testsimplestruct(Persion p, char* res);
extern "C" _declspec(dllexport) void testptrstruct(People * p);


class Operationn
{
};
