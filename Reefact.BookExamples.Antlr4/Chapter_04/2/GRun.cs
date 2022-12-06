#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            LabeledExprLexer  lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new LabeledExprParser(tokens);
            IParseTree        tree   = parser.prog();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, LabeledExprParser parser) : base(tree, parser) { }

        #endregion

        public int[] Eval() {
            EvalVisitor visitor = new();
            Tree.Accept(visitor);

            return visitor.GetResults().ToArray();
        }

    }

}