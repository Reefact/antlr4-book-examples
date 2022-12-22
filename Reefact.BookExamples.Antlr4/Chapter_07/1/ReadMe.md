### 7.1. Evolving from Embedded Actions to Listeners

This example show how to override ANTLR4 generated parser to create a simple property file loader application.

_Remarks:_

_C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 PropertyFile.g4 -Dlanguage=CSharp
```