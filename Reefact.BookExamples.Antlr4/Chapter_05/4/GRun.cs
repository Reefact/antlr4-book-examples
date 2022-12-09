#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadString(string input) {
            AntlrInputStream  inputStream = AntlrInputStreamReader.Read(input);
            PLrALexer         lexer       = new(inputStream);
            CommonTokenStream tokens      = new(lexer);
            var               parser      = new PLrAParser(tokens);
            IParseTree        tree        = parser.calc();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, PLrAParser parser) : base(tree, parser) { }

        #endregion

        public int Eval() {
            EvalVisitor visitor = new();
            Tree.Accept(visitor);

            return visitor.Result;
        }

    }

}