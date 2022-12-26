﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._5 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            RLexer              lexer  = new(inputStream);
            CommonTokenStream   tokens = new(lexer);
            var                 parser = new RParser(tokens);
            RParser.ProgContext tree   = parser.prog();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

    }

}