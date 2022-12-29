#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._5 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            RLexer            lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            var               parser = new RParser(tokens);

            return new GRun(lexer, parser, parser.prog, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, parser, parse, tokenStream) { }

        #endregion

    }

}