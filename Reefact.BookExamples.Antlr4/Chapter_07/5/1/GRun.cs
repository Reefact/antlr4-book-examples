#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var               lexer  = new LExprLexer(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new LExprParser(tokens);

            return new GRun(lexer, parser, parser.s, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public int Eval() {
            EvalVisitor evaluator = new();
            int         result    = evaluator.Visit(Tree);

            return result;
        }

    }

}