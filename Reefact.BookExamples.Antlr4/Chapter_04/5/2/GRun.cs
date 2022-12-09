#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun {

        #region Statics members declarations

        public static GRun ReadResource(string resourceName, params int[] chapter) {
            string            inputString = ResourcesHelper.Read(resourceName, chapter);
            AntlrInputStream  inputStream = AntlrInputStreamReader.Read(inputString);
            JavaLexer         lexer       = new(inputStream);
            CommonTokenStream tokens      = new(lexer);
            var               parser      = new JavaParser(tokens);

            return new GRun(parser, tokens);
        }

        #endregion

        #region Fields declarations

        private readonly JavaParser        _parser;
        private readonly CommonTokenStream _tokens;

        #endregion

        #region Constructors declarations

        private GRun(JavaParser parser, CommonTokenStream tokens) {
            _parser = parser;
            _tokens = tokens;
        }

        #endregion

        public string Rewrite() {
            IParseTree             tree      = _parser.compilationUnit();
            ParseTreeWalker        walker    = new(); // create standard walker
            InsertSerialIdListener extractor = new(_tokens);
            walker.Walk(extractor, tree); // initiate walk of tree with listener

            return extractor.Rewrite();
        }

    }

}