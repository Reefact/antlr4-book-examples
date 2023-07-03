#region Usings declarations

using System.Text;

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class UnderlineListener : BaseErrorListener, IErrorListenerWithOutput {

        #region Fields declarations

        private readonly List<string> _output = new();

        #endregion

        /// <inheritdoc />
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            StringBuilder builder = new();
            builder.AppendLine($"line {line}:{charPositionInLine} {msg}");
            CommonTokenStream? tokens    = (CommonTokenStream)recognizer.InputStream;
            string             input     = tokens.TokenSource.InputStream.ToString() ?? string.Empty;
            string[]           lines     = input.Split(Environment.NewLine);
            string             errorLine = lines[line - 1];
            builder.AppendLine(errorLine);
            for (int i = 0; i < charPositionInLine; i++) {
                builder.Append(" ");
            }
            int start = offendingSymbol.StartIndex;
            int stop  = offendingSymbol.StopIndex;
            if (start >= 0 && stop >= 0) {
                for (int i = start; i <= stop; i++) {
                    builder.Append("^");
                }
            }
            _output.Add(builder.ToString());
        }

        public string GetOutput() {
            return _output.Aggregate((previous, next) => $"{previous}\r\n{next}");
        }

    }

}