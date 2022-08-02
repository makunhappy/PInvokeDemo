[参考](https://docs.microsoft.com/en-us/dotnet/framework/interop/interop-marshalling)
# PInvoke 使用心得

导出函数中，参数类型与c#的类型关系
|c|c#|说明|
|---|---|---|
|void *|IntPtr|结构体中向c#传出数据|
|void**|ref IntPtr|函数参数向c#传出数据|
|unsigned char|byte|
|unsigned char *|ref byte|
|unsigned char *|[MarshalAs(UnmanagedType.LPArray)] byte[]|
|unsigned char *|[MarshalAs(UnmanagedType.LPArray)] Intptr|
|unsigned char &|ref byte|
|unsigned char|byte|
|unsigned short|ushort|
|unsigned int|uint|
|unsigned int*| ref uint|
|unsigned long|ulong|
|unsigned long*|ref ulong|
|char|byte|
|char arr[ARRAYSIZE] |MarshalAs(UnmanagedType.ByValTStr,SizeConst=ARRAYSIZE)]string|结构体中向c++传入参数|
|char *|string|函数参数中向c++传入参数或者结构体中向C#传出|
|char *| [MarshalAsAttribute(UnmanagedType.LPStr)]string|结构体中向c++传入参数或者向c#传出|
|char *|StringBuilder|函数参数中向c#传出参数|
|const char *|string|
|char[]|string|
|struct struct_name *|ref struct struct_name|函数参数中|
|struct struct_name& |ref struct struct_name|函数参数中|
|函数指针|delegate|函数参数中向c++传入|


如果设计目标是c++向c# 传递指针，可以
- 在函数中使用void ** 和ref IntPtr
- 在结构体中使用void* 和IntPtr
如果设计目标是c++向c# 传递结构体，可以
- 在函数中使用struct struct_name *和ref struct_name
- 在结构体中可以直接用struct或者struct struct_name* 和IntPtr


# int数组使用(只能使用一维数组)
函数参数中 c# -> c++ 时，需要指定数组长度，方式为
```dotnet
int TestArray(
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] arr, int cnt);
```
```c
int TestArray(int arr[],int cnt);
```
或者
```dotnet
int TestArray(
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 10)] int[] arr);      
```

```c
int TestArray(int arr[10]);
```
回调函数中数组必须时定长
struct中的数组必须时定长

# string
- 函数参数中可以使用string和stringbuilder,string是in类型，stringbuilder是in out 类型，如果需要out语义，建议使用byte[]或者char[] (结构体中不能使用stringbuilder)
-结构体中
```dotnet
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
struct StringInfoA
{
    [MarshalAs(UnmanagedType.LPStr)] public string f1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string f2;
}
```
```c
struct StringInfoA
{
    char *  f1;
    char    f2[256];
};
```
