#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._3 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            JavaLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new JavaParser(tokens);

            return new GRun(lexer, parser, parser.compilationUnit, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, tokenStream, parser, parse) { }

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