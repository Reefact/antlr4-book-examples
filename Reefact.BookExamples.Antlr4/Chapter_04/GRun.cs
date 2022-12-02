#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            ExprLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new ExprParser(tokens);
            IParseTree        tree   = parser.prog();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, ExprParser parser) : base(tree, parser) { }

        #endregion

    }

}