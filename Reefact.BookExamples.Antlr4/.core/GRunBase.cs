#region Usings declarations

using System.Diagnostics;
using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4;

[DebuggerDisplay("{ToString()}")]
public abstract class GRunBase {

    #region Fields declarations

    private readonly SyntacticalErrorListener _syntacticalErrorListener = new();
    private readonly LexicalErrorListener     _lexicalErrorListener     = new();

    #endregion

    #region Constructors declarations

    protected GRunBase(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) {
        if (lexer is null) { throw new ArgumentNullException(nameof(lexer)); }
        if (parser is null) { throw new ArgumentNullException(nameof(parser)); }
        if (parse is null) { throw new ArgumentNullException(nameof(parse)); }
        if (tokenStream is null) { throw new ArgumentNullException(nameof(tokenStream)); }

        Lexer = lexer;
        Lexer.AddErrorListener(_lexicalErrorListener);
        Parser = parser;
        Parser.AddErrorListener(_syntacticalErrorListener);
        TokenStream = tokenStream;
        Tree        = parse();
    }

    #endregion

    protected IParseTree        Tree        { get; }
    protected Lexer             Lexer       { get; }
    protected Parser            Parser      { get; }
    protected CommonTokenStream TokenStream { get; }

    public string ToLispStyleTree() {
        StringBuilder builder = new();
        AppendErrorsTo(builder);
        builder.Append(Tree.ToStringTree(Parser));

        return builder.ToString();
    }

    public string ToTokensString() {
        return TokenStream.GetTokens()
                          .Select(t => t.ToString())
                          .Aggregate((previous, next) => $"{previous}{Environment.NewLine}{next}") ?? string.Empty;
    }

    public string ToMermaidStyleTree() {
        MermaidStyleTreeBuilder builder = new(Parser);
        ParseTreeWalker         walker  = new();
        walker.Walk(builder, Tree);

        return builder.ToMermaidStyleTree();
    }

    /// <inheritdoc />
    public override string ToString() {
        return ToLispStyleTree();
    }

    protected void AppendErrorsTo(StringBuilder builder) {
        foreach (string errorMessage in _lexicalErrorListener.GetErrorMessages()) {
            builder.AppendLine(errorMessage);
        }
        foreach (string errorMessage in _syntacticalErrorListener.GetErrorMessages()) {
            builder.AppendLine(errorMessage);
        }
    }

    #region Nested types declarations

    private sealed class SyntacticalErrorListener : BaseErrorListener {

        #region Fields declarations

        private readonly List<string> _errorMessages = new();

        #endregion

        /// <inheritdoc />
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            _errorMessages.Add($"line {line}:{charPositionInLine} {msg}");
        }

        public string[] GetErrorMessages() {
            return _errorMessages.ToArray();
        }

    }

    private sealed class LexicalErrorListener : IAntlrErrorListener<int> {

        #region Fields declarations

        private readonly List<string> _errorMessages = new();

        #endregion

        /// <inheritdoc />
        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            _errorMessages.Add($"line {line}:{charPositionInLine} {msg}");
        }

        public string[] GetErrorMessages() {
            return _errorMessages.ToArray();
        }

    }

    #endregion

}