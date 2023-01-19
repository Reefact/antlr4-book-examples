#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            BailSimpleLexer   lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            SimpleParser      parser = new(tokens);
            parser.ErrorHandler = new BailErrorStrategy();

            return new GRun(lexer, tokens, parser, parser.prog);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

    }

}