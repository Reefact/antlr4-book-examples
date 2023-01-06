#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._2 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            ArrayInitLexer    lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new ArrayInitParser(tokens);

            return new GRun(lexer, tokens, parser, parser.init);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

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