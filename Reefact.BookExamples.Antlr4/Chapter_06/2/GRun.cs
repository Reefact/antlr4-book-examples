﻿#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            JSONLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            JSONParser?       parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.json);
        }

        #endregion

        #region Constructors declarations

        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

    }

}