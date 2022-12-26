#### 7.5.1. Traversing Parse Trees with Visitors

This example show the implementation of an evaluator for the LExpr grammar traversing parse tree with a visitor.

_Remarks:_

_C# lexer and parser classes are generated with the following command line using grammar from [chapter 7.4.](../../.antlr/LExpr.g4) :_

```bat
antlr4 -no-listener -visitor LExpr.g4 -Dlanguage=CSharp
```