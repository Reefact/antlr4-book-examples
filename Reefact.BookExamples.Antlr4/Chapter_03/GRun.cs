﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            ArrayInitLexer    lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new ArrayInitParser(tokens);

            return new GRun(lexer, parser, parser.init, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, parser, parse, tokenStream) { }

        #endregion

        public string ToUnicodeString() {
            // create a generic parse tree walker that can trigger callbacks
            var walker = new ParseTreeWalker();
            // walk the tree created during the parse, trigger callbacks
            ShortToUnicodeStringListener shortToUnicodeString = new();
            walker.Walk(shortToUnicodeString, Tree);

            return shortToUnicodeString.ToString();
        }

    }

}