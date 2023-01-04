#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            FLexer            lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            FParser           parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.group);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

    }

}