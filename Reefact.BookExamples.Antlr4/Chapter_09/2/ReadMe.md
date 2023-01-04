### 9.2. Altering and Redirecting ANTLR Error Messages

This example show how errors can be handled by custom errors listener.

_Remarks:_

_C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 Ambig.g4 -Dlanguage=CSharp
```