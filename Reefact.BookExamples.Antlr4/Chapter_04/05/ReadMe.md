## 4.4. Making Things Happen During the Parse

This example shows how to embed arbitrary actions into a grammar.

_Remarks: C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 -no-listener Rows.g4 -Dlanguage=CSharp
```