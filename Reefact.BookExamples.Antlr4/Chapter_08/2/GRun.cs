#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._2 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var                        lexer  = new JSON_8_2Lexer(inputStream);
            CommonTokenStream          tokens = new(lexer);
            var                        parser = new JSON_8_2Parser(tokens);
            JSON_8_2Parser.JsonContext tree   = parser.json();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public string Translate() {
            ParseTreeWalker walker     = new();
            XmlEmitter      xmlEmitter = new();
            walker.Walk(xmlEmitter, Tree);

            return xmlEmitter.GetXml();
        }

    }

}