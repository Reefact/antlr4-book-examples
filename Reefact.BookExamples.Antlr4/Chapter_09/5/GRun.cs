#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream, IAntlrErrorStrategy errorStrategy) {
            BailSimpleLexer   lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            SimpleParser      parser = new(tokens);
            parser.ErrorHandler = errorStrategy;

            return new GRun(lexer, tokens, parser, parser.prog);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

        public string GetOutput() {
            StringBuilder builder = new();
            AppendErrorsTo(builder);
            builder.Append(((SimpleParser)Parser).GetOutput()
                                                 .Aggregate((p, n) => $"{p}{Environment.NewLine}{n}"));

            return builder.ToString();
        }

    }

}