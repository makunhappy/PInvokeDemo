#pragma once
#include<bitset>

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
struct Persion1
{
	char name[50];
	int age;
	int score;
};
struct People
{
	struct Persion* persion;
	int count;

};
struct LogData
{
	char data[256];
};
enum class LogType
{
	Type1 = 0,
	Type2 = 1,
};
struct LogInfo
{
	LogData logs[20];
	int count;
	std::bitset<32> bits;
	LogType log_type;
};

struct RetStruct
{
	int i;
	char Message[50];
};

extern "C" _declspec(dllexport) int sum(int, int);
extern "C" _declspec(dllexport) void test(void* callBack);
extern "C" _declspec(dllexport) void testcallback(void* callBack);
extern "C" _declspec(dllexport) void testenum(Day day, char* v);
extern "C" _declspec(dllexport) void testsimplestruct(Persion p, char* res);
extern "C" _declspec(dllexport) void testsimplestructwithclass(Persion1 * p);
extern "C" _declspec(dllexport) void testptrstruct(People * p);


class Operationn
{
};


#pragma region global variable
extern "C" _declspec(dllexport) void SetVariable(int i);
extern "C" _declspec(dllexport) int GetVariable();
#pragma endregion

extern "C" _declspec(dllexport) int TestBuf(void** p);
extern "C" _declspec(dllexport) int FreeBuf(void* p);

extern "C" _declspec(dllexport) int InputCharStar(char* arr);

extern "C" _declspec(dllexport) int TestArray(int arr[], int count);

extern "C" _declspec(dllexport) int TestCallBackMemroy(void* p);

struct ArrayInStruct
{
	int Pos[2];
};

extern "C" _declspec(dllexport) int TestArrayInStruct(ArrayInStruct  p);

extern "C" _declspec(dllexport) RetStruct TestReturnStruct();

struct TestBoolStruct
{
	bool Adult;
	char Address[128];
};

extern "C" _declspec(dllexport) int TestBool(TestBoolStruct tmp);