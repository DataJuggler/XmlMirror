# XmlMirror
XmlMirror uses reflection to make it simple to create C# XML Parsers and Writers

Update 4.3.2022: I upgraded this project to .NET6, and I created a port of XmlMirror.Runtime5 and created XmlMirror.Runtime6, for you guess it, .NET6.


I also learned ReflectionOnlyLoading is no longer supported. The fix was changing Assebmlty.ReflectionOnlyLoadFrom to Assebmlty.LoadFrom(dllPath);

Seems to work since upgrading, making a new video now to verify.
