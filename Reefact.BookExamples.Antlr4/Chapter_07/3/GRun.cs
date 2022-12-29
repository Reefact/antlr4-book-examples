#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var               lexer  = new PropertyFile_7_3Lexer(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new PropertyFile_7_3Parser(tokens);

            return new GRun(lexer, parser, parser.file, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, parser, parse, tokenStream) { }

        #endregion

        public string ToPropertiesString() {
            PropertyFileLoader visitor = new();
            Tree.Accept(visitor);

            return visitor.ToString();
        }

    }

}