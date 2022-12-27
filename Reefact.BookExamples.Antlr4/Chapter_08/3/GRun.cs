#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            var                          lexer  = new Cymbol_8_3Lexer(inputStream);
            CommonTokenStream            tokens = new(lexer);
            var                          parser = new Cymbol_8_3Parser(tokens);
            Cymbol_8_3Parser.FileContext tree   = parser.file();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) { }

        #endregion

        public string ToDot() {
            ParseTreeWalker    walker    = new();
            CallGraphGenerator generator = new();
            walker.Walk(generator, Tree);

            return generator.ToDot();
        }

    }

}