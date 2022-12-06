#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._04 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            JavaLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new JavaParser(tokens);
            IParseTree        tree   = parser.compilationUnit();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, JavaParser parser) : base(tree, parser) { }

        #endregion

        private new JavaParser Parser => (JavaParser)base.Parser;

        public string ExtractInterface() {
            ParseTreeWalker          walker    = new();
            ExtractInterfaceListener extractor = new(Parser);
            walker.Walk(extractor, Tree);

            return extractor.ToString();
        }

    }

}