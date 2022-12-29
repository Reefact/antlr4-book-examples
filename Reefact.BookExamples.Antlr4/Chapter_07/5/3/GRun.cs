﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._3 {

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
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, parser, parse, tokenStream) { }

        #endregion

        public int Eval() {
            ParseTreeWalker       walker    = new();
            EvalListenerWithProps evaluator = new();
            walker.Walk(evaluator, Tree);

            return evaluator.Eval();
        }

    }

}