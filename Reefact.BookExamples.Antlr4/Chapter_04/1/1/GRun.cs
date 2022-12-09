#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._1 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadResource(string resourceName, params int[] chapter) {
            string            inputString = ResourcesHelper.Read(resourceName, chapter);
            AntlrInputStream  inputStream = AntlrInputStreamReader.Read(inputString);
            ExprLexer         lexer       = new(inputStream);
            CommonTokenStream tokens      = new(lexer);
            var               parser      = new ExprParser(tokens);
            IParseTree        tree        = parser.prog();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, ExprParser parser) : base(tree, parser) { }

        #endregion

    }

}