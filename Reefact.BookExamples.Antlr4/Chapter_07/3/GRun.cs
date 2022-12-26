#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var                                lexer  = new PropertyFile_7_3Lexer(inputStream);
            CommonTokenStream                  tokens = new(lexer);
            var                                parser = new PropertyFile_7_3Parser(tokens);
            PropertyFile_7_3Parser.FileContext tree   = parser.file();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public string ToPropertiesString() {
            PropertyFileLoader visitor = new();
            Tree.Accept(visitor);

            return visitor.ToString();
        }

    }

}