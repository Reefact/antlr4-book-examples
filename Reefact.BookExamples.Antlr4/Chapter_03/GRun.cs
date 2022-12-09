#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadString(string input) {
            AntlrInputStream  inputStream = AntlrInputStreamReader.Read(input);
            ArrayInitLexer    lexer       = new(inputStream);
            CommonTokenStream tokens      = new(lexer);
            var               parser      = new ArrayInitParser(tokens);
            IParseTree        tree        = parser.init();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, ArrayInitParser parser) : base(tree, parser) { }

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