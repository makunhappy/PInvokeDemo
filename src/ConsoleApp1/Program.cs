// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Runtime.InteropServices;
using System.Text;

var res = NativeMethods.Sum(1, 2);
NativeMethods.printLog = PrintLog;
NativeMethods.Test(NativeMethods.printLog);
StringBuilder day = new StringBuilder();
NativeMethods.TestEnum(Day.Monday, day);
StringBuilder sb = new StringBuilder();
NativeMethods.TestSimpleStruct(new Persion { name = "name", age = 18, score = 100 }, sb);
#region intptr
var p = Marshal.AllocHGlobal((int)Marshal.SizeOf<Persion>());
NativeMethods.TestPtrStruct(p);
var people = Marshal.PtrToStructure<People>(p);
var persion = Marshal.PtrToStructure<Persion>(people.persion);
Marshal.FreeHGlobal(p);
#endregion
Console.WriteLine("Hello, World!");
Console.Read();

void PrintLog(int msg)
{
    Console.WriteLine(msg);
}