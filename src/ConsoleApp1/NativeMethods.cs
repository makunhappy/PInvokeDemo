using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class NativeMethods
    {
        //普通调用
        [DllImport("Dlls.dll", EntryPoint = "sum", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sum(int a, int b);
        [DllImport("Dlls.dll", EntryPoint = "sum", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sum(int a, int b, int c);
        public delegate void PrintLog(int msg);
        public static PrintLog printLog;
        public delegate void LogCallback(LogInfo msg);
        public static LogCallback logCallback;
        //回调函数
        [DllImport("Dlls.dll", EntryPoint = "test", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Test(PrintLog callBack);
        //回调函数
        [DllImport("Dlls.dll", EntryPoint = "testcallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestCallback(LogCallback callBack);
        //枚举
        [DllImport("Dlls.dll", EntryPoint = "testenum", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestEnum(Day day, StringBuilder v);
        [DllImport("Dlls.dll", EntryPoint = "testsimplestruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestSimpleStruct(Persion p, StringBuilder sb);
        [DllImport("Dlls.dll", EntryPoint = "testsimplestructwithclass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestSimpleStructWithClass([Out] Persion1 p);
        //People intptr
        [DllImport("Dlls.dll", EntryPoint = "testptrstruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestPtrStruct(IntPtr p);
        [DllImport("Dlls.dll", EntryPoint = "testptrstruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestPtrStruct1(ref People p);
        [DllImport("Dlls.dll", EntryPoint = "testptrstruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestPtrStruct2(out People p);

        [DllImport("Dlls.dll", EntryPoint = "SetVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVariable(int v);
        [DllImport("Dlls.dll", EntryPoint = "GetVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVariable();

        [DllImport("Dlls.dll", EntryPoint = "TestBuf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TestBuf(ref IntPtr p);
        [DllImport("Dlls.dll", EntryPoint = "FreeBuf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FreeBuf(IntPtr p);

        [DllImport("Dlls.dll", EntryPoint = "InputCharStar", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InputCharStar(string msg);

        [DllImport("Dlls.dll", EntryPoint = "TestArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TestArray(
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] arr, int cnt);
    }
    public enum Day
    {
        SunDay,
        Monday,
    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Persion
    {

        /// char*
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string name;

        /// int
        public int age;

        /// int
        public int score;
    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class Persion1
    {

        /// char*
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string name;

        /// int
        public int age;

        /// int
        public int score;
    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct People
    {

        /// Persion*
        public System.IntPtr persion;

        /// int
        public int count;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct LogInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public LogData[] logInfo;
        public int count;
        public int bits;
        public LogType type;
    }
    public enum LogType
    {
        Type1 = 0,
        Type2 = 1,
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct LogData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        string data;
    };
}
