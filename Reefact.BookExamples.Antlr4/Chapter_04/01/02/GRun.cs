#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._02 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            LibExprLexer      lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new LibExprParser(tokens);
            IParseTree        tree   = parser.prog();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, LibExprParser parser) : base(tree, parser) { }

        #endregion

    }

}