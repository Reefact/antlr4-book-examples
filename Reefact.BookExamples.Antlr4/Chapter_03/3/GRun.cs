#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._3 {

    public sealed class GRun {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            // create a lexer that feeds off of input stream
            ArrayInitLexer lexer = new(inputStream);
            // create a buffer of tokens pulled from the lexer
            CommonTokenStream tokens = new(lexer);
            // create a parser that feeds off the tokens buffer
            ArrayInitParser? parser = new(tokens);
            // begin parsing at init rule
            IParseTree tree = parser.init();

            return new GRun(parser, tree);
        }

        #endregion

        #region Fields declarations

        private readonly ArrayInitParser _parser;
        private readonly IParseTree      _tree;

        #endregion

        #region Constructors declarations

        private GRun(ArrayInitParser parser, IParseTree tree) {
            _parser = parser;
            _tree   = tree;
        }

        #endregion

        public string ToLispStyleTree() {
            return _tree.ToStringTree(_parser); // print LISP-style tree
        }

    }

}