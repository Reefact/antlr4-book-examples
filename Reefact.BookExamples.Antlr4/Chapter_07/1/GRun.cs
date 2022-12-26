#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            PropertyFile_7_1Lexer              lexer  = new(inputStream);
            CommonTokenStream                  tokens = new(lexer);
            var                                parser = new PropertyFileLoader(tokens);
            PropertyFile_7_1Parser.FileContext tree   = parser.file();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public string ToPropertiesString() {
            return Parser.ToString() ?? string.Empty;
        }

    }

}