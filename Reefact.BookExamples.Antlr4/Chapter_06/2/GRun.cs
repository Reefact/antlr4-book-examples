#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadResource(string resourceName, params int[] chapter) {
            string           inputString = ResourcesHelper.Read(resourceName, chapter);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(inputString);

            return ReadStream(inputStream);
        }

        public static GRun ReadString(string inputString) {
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(inputString);

            return ReadStream(inputStream);
        }

        private static GRun ReadStream(AntlrInputStream inputStream) {
            JSONLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new JSONParser(tokens);
            IParseTree        tree   = parser.json();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, JSONParser parser, CommonTokenStream commonTokenStream) : base(tree, parser, commonTokenStream) { }

        #endregion

    }

}