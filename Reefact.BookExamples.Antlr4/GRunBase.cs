#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4;

[DebuggerDisplay("{ToString()}")]
public abstract class GRunBase {

    #region Constructors declarations

    protected GRunBase(IParseTree tree, Parser parser, CommonTokenStream tokenStream) {
        if (tree is null) { throw new ArgumentNullException(nameof(tree)); }
        if (parser is null) { throw new ArgumentNullException(nameof(parser)); }
        if (tokenStream is null) { throw new ArgumentNullException(nameof(tokenStream)); }

        Tree        = tree;
        Parser      = parser;
        TokenStream = tokenStream;
    }

    #endregion

    protected         IParseTree        Tree        { get; }
    protected virtual Parser            Parser      { get; }
    public            CommonTokenStream TokenStream { get; }

    public string ToLispStyleTree() {
        return Tree.ToStringTree(Parser);
    }

    public string ToTokensString() {
        return TokenStream.GetTokens()
                          .Select(t => t.ToString())
                          .Aggregate((previous, next) => $"{previous}{Environment.NewLine}{next}") ?? string.Empty;
    }

    public string ToMermaidStyleTree() {
        string                                 lispStyleTree = ToLispStyleTree();
        AntlrInputStream                       inputStream   = AntlrInputStreamReader.Read(lispStyleTree);
        LispStyleTreeLexer                     lexer         = new(inputStream);
        CommonTokenStream                      tokens        = new(lexer);
        var                                    parser        = new LispStyleTreeParser(tokens);
        LispStyleTreeParser.Parent_nodeContext tree          = parser.parent_node();
        ParseTreeWalker                        walker        = new();
        MermaidStyleTreeBuilder                builder       = new();
        walker.Walk(builder, tree);

        return builder.ToString();
    }

    /// <inheritdoc />
    public override string ToString() {
        return ToLispStyleTree();
    }

}