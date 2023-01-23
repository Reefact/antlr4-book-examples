#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    public sealed class MyErrorStrategy : DefaultErrorStrategy {

        /// <inheritdoc />
        protected override void ReportNoViableAlternative(Parser recognizer, NoViableAltException exception) {
            // ANTLR generates Parser subclasses from grammars and
            // Parser extends Recognizer. Parameter parser is a
            // pointer to the parser that detected the error
            var nonStandardMessage = "Can't choose between alternatives";
            recognizer.NotifyErrorListeners(exception.OffendingToken, nonStandardMessage, exception);
        }

    }

}