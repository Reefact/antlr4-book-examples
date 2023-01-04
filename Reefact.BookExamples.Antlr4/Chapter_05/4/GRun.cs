#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            PLrALexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new PLrAParser(tokens);

            return new GRun(lexer, parser, parser.expr, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public int Eval() {
            EvalVisitor visitor = new();

            return visitor.Visit(Tree);
        }

    }

}