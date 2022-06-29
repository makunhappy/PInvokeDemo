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
        public delegate void PrintLog(int msg);
        public static PrintLog printLog;
        //回调函数
        [DllImport("Dlls.dll", EntryPoint = "test", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Test(PrintLog callBack);
        //枚举
        [DllImport("Dlls.dll", EntryPoint = "testenum", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestEnum(Day day, StringBuilder v);
        [DllImport("Dlls.dll", EntryPoint = "testsimplestruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestSimpleStruct(Persion p, StringBuilder sb);
        //People intptr
        [DllImport("Dlls.dll", EntryPoint = "testptrstruct", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TestPtrStruct(IntPtr p);

        [DllImport("Dlls.dll", EntryPoint = "SetVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVariable(int v);
        [DllImport("Dlls.dll", EntryPoint = "GetVariable", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVariable();
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
    public struct People
    {

        /// Persion*
        public System.IntPtr persion;

        /// int
        public int count;
    }

}
