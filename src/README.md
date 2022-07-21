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
