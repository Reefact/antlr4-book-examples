#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03;

public sealed class _EntryPoint {

    #region Statics members declarations

    public static _EntryPoint Read(string s) {
        // create a CharStream that reads from input string
        using TextReader stream = new StringReader(s);
        AntlrInputStream input  = new(stream);

        // create a lexer that feeds off of input CharStream
        ArrayInitLexer lexer = new(input);

        // create a buffer of tokens pulled from the lexer
        CommonTokenStream tokens = new(lexer);

        // create a parser that feeds off the tokens buffer
        var parser = new ArrayInitParser(tokens);

        // begin parsing at 'init' rule
        IParseTree tree = parser.init();

        return new _EntryPoint(tree, parser);
    }

    #endregion

    #region Fields declarations

    private readonly ArrayInitParser _parser;
    private readonly IParseTree      _tree;

    #endregion

    #region Constructors declarations

    private _EntryPoint(IParseTree tree, ArrayInitParser parser) {
        _tree   = tree;
        _parser = parser;
    }

    #endregion

    public string ToListStyleTree() {
        return _tree.ToStringTree(_parser);
    }

    public string ToUnicodeString() {
        // create a generic parse tree walker that can trigger callbacks
        var walker = new ParseTreeWalker();
        // walk the tree created during the parse, trigger callbacks
        ShortToUnicodeString shortToUnicodeString = new();
        walker.Walk(shortToUnicodeString, _tree);

        return shortToUnicodeString.ToString();
    }

}