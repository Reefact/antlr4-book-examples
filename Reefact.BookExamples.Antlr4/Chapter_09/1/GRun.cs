#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._1 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            SimpleLexer       lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            SimpleParser      parser = new(tokens);

            return new GRun(lexer, parser, parser.prog, tokens);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) : base(lexer, tokenStream, parser, parse) { }

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