// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text;
/*
var res = NativeMethods.Sum(1, 2);
res = NativeMethods.Sum(1, 2, 3);
NativeMethods.printLog = PrintLog;
NativeMethods.Test(NativeMethods.printLog);
*/
#region 二维数组可以在以为数组中包一个一维数组
NativeMethods.logCallback = TestCallback;
NativeMethods.TestCallback(NativeMethods.logCallback);
#endregion
/*
StringBuilder day = new StringBuilder();
NativeMethods.TestEnum(Day.Monday, day);
string s = new String('a', 20);
NativeMethods.InputCharStar(s);
StringBuilder sb = new StringBuilder();
NativeMethods.TestSimpleStruct(new Persion { name = "name", age = 18, score = 100 }, sb);
#region intptr
var p = Marshal.AllocHGlobal((int)Marshal.SizeOf<Persion>());
NativeMethods.TestPtrStruct(p);
var people = Marshal.PtrToStructure<People>(p);
var persion = Marshal.PtrToStructure<Persion>(people.persion);
Marshal.FreeHGlobal(p);
#endregion
People p1 = new People();
NativeMethods.TestPtrStruct1(ref p1);
People p2;
NativeMethods.TestPtrStruct2(out p2);
NativeMethods.SetVariable(100);
var v = NativeMethods.GetVariable();
IntPtr ptr = new IntPtr();
NativeMethods.TestBuf(ref ptr);
unsafe
{
    int* p = (int*)ptr;
}
NativeMethods.FreeBuf(ptr);
*/
//Persion1 p = new Persion1() { name = "kangkang"};
//NativeMethods.TestSimpleStructWithClass( p);
//int[] a = { 1, 2, 3, 4, 5, 6 };
//NativeMethods.TestArray(a, a.Length);

//NativeMethods.memoryCallBack = TestCallbackM;
//NativeMethods.TestCallBackMemory(NativeMethods.memoryCallBack, 1000);

//NativeMethods.TestArrayInStruct(new ArrayInStruct { Pos = new int[] { 0, 90 } });

//var ret = NativeMethods.TestReturnStruct();
var para = new TestBoolStruct() { Address = "bei", Adult = true };
var res = NativeMethods.TestBool(para);

Console.WriteLine("Hello, World!");
Console.Read();
static void TestCallbackM(IntPtr ptr)
{

}
static void PrintLog(int msg)
{
    Console.WriteLine(msg);
}
static void TestCallback(LogInfo info)
{

}