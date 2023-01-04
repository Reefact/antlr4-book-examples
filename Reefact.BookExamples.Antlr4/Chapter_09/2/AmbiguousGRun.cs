#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using Reefact.BookExamples.Antlr4.core;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class AmbiguousGRun {

        #region Statics members declarations

        public static AmbiguousGRun Read(AntlrInputStream inputStream) {
            AmbigLexer        lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            AmbigParser       parser = new(tokens);

            return new AmbiguousGRun(parser, parser.stat);
        }

        #endregion

        #region Fields declarations

        private readonly AmbigParser      _parser;
        private readonly Func<IParseTree> _parse;

        #endregion

        #region Constructors declarations

        private AmbiguousGRun(AmbigParser parser, Func<IParseTree> parse) {
            _parser = parser;
            _parse  = parse;
        }

        #endregion

        public string GetOutput(BaseErrorListener errorListener, Action<Parser>? options = null) {
            return GetOutput(new[] { errorListener }, options);
        }

        public string GetOutput(BaseErrorListener[] errorListeners, Action<Parser>? options = null) {
            if (options != null) {
                options(_parser);
            }
            _parser.RemoveErrorListeners();
            foreach (BaseErrorListener errorListener in errorListeners) {
                _parser.AddErrorListener(errorListener);
            }
            _parse();
            StringBuilder builder = new();
            foreach (BaseErrorListener errorListener in errorListeners) {
                if (errorListener is not IErrorListenerWithOutput errorListenerWithOutput) { continue; }

                builder.AppendLine(errorListenerWithOutput.GetOutput());
            }

            var output = builder.ToString();

            return output.RemoveTrailing(Environment.NewLine);
        }

    }

}