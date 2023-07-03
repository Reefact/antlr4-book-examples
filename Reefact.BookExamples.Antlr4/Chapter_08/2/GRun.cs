#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._2 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            JSON_8_2Lexer?    lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            JSON_8_2Parser?   parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.json);
        }

        #endregion

        #region Constructors declarations

        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public string Translate() {
            ParseTreeWalker walker     = new();
            XmlEmitter      xmlEmitter = new();
            walker.Walk(xmlEmitter, Tree);

            return xmlEmitter.GetXml();
        }

    }

}