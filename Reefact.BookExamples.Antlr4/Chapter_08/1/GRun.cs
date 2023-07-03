#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            CSV_8_1Lexer?     lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            CSV_8_1Parser?    parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.file);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public List<Dictionary<string, string>> Load() {
            ParseTreeWalker walker = new();
            CsvLoader       loader = new();
            walker.Walk(loader, Tree);

            return loader.GetData();
        }

    }

}