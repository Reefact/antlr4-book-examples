#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            LExprLexer?       lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            LExprParser?      parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.s);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public int Eval() {
            ParseTreeWalker       walker    = new();
            EvalListenerWithProps evaluator = new();
            walker.Walk(evaluator, Tree);

            return evaluator.Eval();
        }

    }

}