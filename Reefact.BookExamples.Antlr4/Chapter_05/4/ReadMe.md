### 5.4. Dealing with Precedence, Left Recursion, and Associativity

This example shows how to handle operator precedence and associativity direction for a simple calculator.

_Remarks:_

_C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 -no-listener -visitor PLrA.g4 -Dlanguage=CSharp
```