#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            PropertyFile_7_3Lexer?  lexer  = new(inputStream);
            CommonTokenStream       tokens = new(lexer);
            PropertyFile_7_3Parser? parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.file);
        }

        #endregion

        #region Constructors declarations

        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public string ToPropertiesString() {
            PropertyFileLoader visitor = new();
            Tree.Accept(visitor);

            return visitor.ToString();
        }

    }

}