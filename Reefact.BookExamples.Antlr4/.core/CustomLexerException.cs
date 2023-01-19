// ReSharper disable once CheckNamespace

namespace Reefact.BookExamples.Antlr4 {

    public class CustomLexerException : ApplicationException {

        #region Constructors declarations

        public CustomLexerException() { }
        public CustomLexerException(string message) : base(message) { }
        public CustomLexerException(string message, Exception inner) : base(message, inner) { }

        #endregion

    }

}