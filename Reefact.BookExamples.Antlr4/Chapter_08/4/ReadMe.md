### 8.4. Validating Program Symbol Usage

This example show how to verify that a Cymbol program use symbols (identifiers) properly:

- variables references should have corresponding definitions that are visible to them (in scope)
- function references should have corresponding definitions
- variables should not used as functions
- functions should not used as variables

_Remarks:_

_C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 Cymbol_8_4.g4 -Dlanguage=CSharp
```