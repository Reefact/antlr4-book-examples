#### 4.5.1. Island Grammars: Dealing with Different Formats in the Same File

This example shows how to use the lexer feature called _lexical modes_ that lets deal with files containing mixed formats (eg. C# file with both C# language + documentation comments language) also called _island grammars_.

_Remarks: C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 XmlLexer.g4 -Dlanguage=CSharp
```