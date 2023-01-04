#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            PropertyFile_7_1Lexer lexer  = new(inputStream);
            CommonTokenStream     tokens = new(lexer);
            var                   parser = new PropertyFileLoader(tokens);

            return new GRun(lexer, parser, parser.file, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public string ToPropertiesString() {
            return Parser.ToString() ?? string.Empty;
        }

    }

}