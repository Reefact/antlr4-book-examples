#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var                       lexer  = new CSV_8_1Lexer(inputStream);
            CommonTokenStream         tokens = new(lexer);
            var                       parser = new CSV_8_1Parser(tokens);
            CSV_8_1Parser.FileContext tree   = parser.file();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public List<Dictionary<string, string>> Load() {
            ParseTreeWalker walker = new();
            CsvLoader       loader = new();
            walker.Walk(loader, Tree);

            return loader.GetData();
        }

    }

}