#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun {

        #region Statics members declarations

        public static GRun Read(string s) {
            if (s is null) { throw new ArgumentNullException(nameof(s)); }

            // create a CharStream that reads from input string
            using TextReader stream = new StringReader(s);
            AntlrInputStream input  = new(stream);

            // create a lexer that feeds off of input CharStream
            ArrayInitLexer lexer = new(input);

            // create a buffer of tokens pulled from the lexer
            CommonTokenStream tokens = new(lexer);

            // create a parser that feeds off the tokens buffer
            var parser = new ArrayInitParser(tokens);

            // begin parsing at 'init' rule
            IParseTree tree = parser.init();

            return new GRun(tree, parser);
        }

        #endregion

        #region Fields declarations

        private readonly ArrayInitParser _parser;

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, ArrayInitParser parser) {
            Tree    = tree;
            _parser = parser;
        }

        #endregion

        public IParseTree Tree { get; }

        public string ToLispStyleTree() {
            return Tree.ToStringTree(_parser);
        }

        /// <inheritdoc />
        public override string ToString() {
            return ToLispStyleTree();
        }

    }

}