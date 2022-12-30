#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class GRun {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            SimpleLexer       lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            SimpleParser      parser = new(tokens);

            return new GRun(parser, parser.prog);
        }

        #endregion

        #region Fields declarations

        private readonly SimpleParser     _parser;
        private readonly Func<IParseTree> _parse;

        #endregion

        #region Constructors declarations

        private GRun(SimpleParser parser, Func<IParseTree> parse) {
            _parser = parser;
            _parse  = parse;
        }

        #endregion

        public string GetOutput(BaseErrorListener errorListener) {
            _parser.RemoveErrorListeners();
            _parser.AddErrorListener(errorListener);
            _parse();
            StringBuilder builder = new();
            if (errorListener is IErrorListenerWithOutput errorListenerWithOutput) {
                builder.AppendLine(errorListenerWithOutput.GetOutput());
            }
            builder.Append(_parser.GetOutput()
                                  .Aggregate((p, n) => $"{p}{Environment.NewLine}{n}"));

            return builder.ToString();
        }

    }

}