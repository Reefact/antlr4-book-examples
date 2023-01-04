#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            JavaLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new JavaParser(tokens);

            return new GRun(lexer, tokens, parser, parser.compilationUnit);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

        public string Rewrite() {
            ParseTreeWalker        walker    = new(); // create standard walker
            InsertSerialIdListener extractor = new(TokenStream);
            walker.Walk(extractor, Tree); // initiate walk of tree with listener

            return extractor.Rewrite();
        }

    }

}