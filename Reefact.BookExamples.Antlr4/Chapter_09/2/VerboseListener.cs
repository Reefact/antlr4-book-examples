#region Usings declarations

using System.Text;

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class VerboseListener : BaseErrorListener, IErrorListenerWithOutput {

        #region Fields declarations

        private readonly List<string> _output = new();

        #endregion

        /// <inheritdoc />
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            StringBuilder builder = new();
            string ruleInvocationStack = ((Parser)recognizer).GetRuleInvocationStack()
                                                             .Reverse()
                                                             .Aggregate((previous, next) => $"{previous} -> {next}");
            builder.AppendLine($"rule stack: [{ruleInvocationStack}]");
            builder.Append($"line {line}:{charPositionInLine} at {offendingSymbol}: {msg}");
            _output.Add(builder.ToString());
        }

        public string GetOutput() {
            return _output.DefaultIfEmpty().Aggregate((previous, next) => $"{previous}\r\n{next}") ?? string.Empty;
        }

    }

}