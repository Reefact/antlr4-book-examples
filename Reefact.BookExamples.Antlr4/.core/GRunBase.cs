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

    private readonly GRunLexicalErrorListener _lexicalErrorListener = new();

    #endregion

    #region Constructors declarations

    protected GRunBase(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : this(lexer, tokenStream, parser, parse, options, new GRunSyntacticalErrorListener()) { }

    protected GRunBase(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options, params BaseErrorListener[] syntacticalErrorListeners) {
        if (lexer is null) { throw new ArgumentNullException(nameof(lexer)); }
        if (tokenStream is null) { throw new ArgumentNullException(nameof(tokenStream)); }
        if (parser is null) { throw new ArgumentNullException(nameof(parser)); }
        if (parse is null) { throw new ArgumentNullException(nameof(parse)); }
        if (syntacticalErrorListeners is null) { throw new ArgumentNullException(nameof(syntacticalErrorListeners)); }

        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(_lexicalErrorListener);
        Lexer = lexer;
        options?.Invoke(parser);
        SyntacticalErrorListeners = syntacticalErrorListeners;
        parser.RemoveErrorListeners();
        foreach (BaseErrorListener syntacticalErrorListener in SyntacticalErrorListeners) {
            parser.AddErrorListener(syntacticalErrorListener);
        }
        Parser      = parser;
        TokenStream = tokenStream;

        Tree = parse();
    }

    #endregion

    protected virtual IParseTree          Tree                      { get; }
    protected virtual Lexer               Lexer                     { get; }
    protected virtual Parser              Parser                    { get; }
    protected         CommonTokenStream   TokenStream               { get; }
    protected         BaseErrorListener[] SyntacticalErrorListeners { get; }

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

        foreach (BaseErrorListener syntacticalErrorListener in SyntacticalErrorListeners) {
            if (syntacticalErrorListener is not GRunSyntacticalErrorListener grunSyntacticalErrorListener) { continue; }

            foreach (string errorMessage in grunSyntacticalErrorListener.GetErrorMessages()) {
                builder.AppendLine(errorMessage);
            }
        }
    }

    #region Nested types declarations

    private sealed class GRunSyntacticalErrorListener : BaseErrorListener {

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

    private sealed class GRunLexicalErrorListener : IAntlrErrorListener<int> {

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