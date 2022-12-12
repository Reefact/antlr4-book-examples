### 5.6. Drawing the Line Between Lexer and Parser

This example shows that it is possible to choose which of the lexer or the parser should match a particular grammatical structure depending on the application context.

NB: 

_Remarks: C# lexer and parser classes are generated with the following command lines:_

```bat
antlr4 IP_Lexer.g4 -Dlanguage=CSharp
antlr4 -no-listener -visitor IP_Parser.g4 -Dlanguage=CSharp
```