# PInvoke 使用心得

导出函数中，参数类型与c#的类型关系
|c|c#|说明|
|---|---|---|
|void *|IntPtr|
|void**|ref IntPtr|
|unsigned char|byte|
|unsigned char *|ref byte|
|unsigned char *|[MarshalAs(UnmanagedType.LPArray)] byte[]|
|unsigned char *|[MarshalAs(UnmanagedType.LPArray)] Intptr|
|unsigned char &|ref byte
|unsigned char|byte|
|unsigned short|ushort|
|unsigned int|uint|
|unsigned long|ulong|
|char|byte|
|char arr[ARRAYSIZE] |MarshalAs(UnmanagedType.ByValTStr,SizeConst=ARRAYSIZE)]string|
|char *|string|
|char *|StringBuilder|
|char *|ref string|
|char *|string|
|char *|[MarshalAs(UnmanagedType.LPStr)]StringBuilder|
|char **    |string|
|char **|ref string|
|const char *|string|
|char[]|string|