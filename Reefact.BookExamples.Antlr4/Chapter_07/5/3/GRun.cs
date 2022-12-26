﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var                  lexer  = new LExprLexer(inputStream);
            CommonTokenStream    tokens = new(lexer);
            var                  parser = new LExprParser(tokens);
            LExprParser.SContext tree   = parser.s();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public int Eval() {
            ParseTreeWalker       walker    = new();
            EvalListenerWithProps evaluator = new();
            walker.Walk(evaluator, Tree);

            return evaluator.Eval();
        }

    }

}