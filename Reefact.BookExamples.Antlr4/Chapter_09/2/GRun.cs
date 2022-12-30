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

            return new GRun(lexer, parser, parser.prog, tokens);
        }

        #endregion

        #region Fields declarations

        private readonly SimpleLexer       _lexer;
        private readonly SimpleParser      _parser;
        private readonly Func<IParseTree>  _parse;
        private readonly CommonTokenStream _tokenStream;
        private readonly VerboseListener   _syntacticalErrorListener;

        #endregion

        #region Constructors declarations

        private GRun(SimpleLexer lexer, SimpleParser parser, Func<IParseTree> parse, CommonTokenStream tokenStream) {
            _lexer                    = lexer;
            _parser                   = parser;
            _syntacticalErrorListener = new VerboseListener();
            _parser.RemoveErrorListeners();
            _parser.AddErrorListener(_syntacticalErrorListener);
            _parse       = parse;
            _tokenStream = tokenStream;
        }

        #endregion

        public string GetOutput() {
            IParseTree    tree    = _parse();
            StringBuilder builder = new();
            builder.AppendLine(_syntacticalErrorListener.GetOutput());
            builder.Append(_parser.GetOutput()
                                  .Aggregate((p, n) => $"{p}{Environment.NewLine}{n}"));

            return builder.ToString();
        }

    }

}