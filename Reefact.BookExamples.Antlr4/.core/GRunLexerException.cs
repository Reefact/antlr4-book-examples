#region Usings declarations

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4;

public class GRunLexerException : Exception {

    #region Constructors declarations

    public GRunLexerException(string message, string[] errorDetails, CustomLexerException innerException) : base(message, innerException) {
        ErrorDetails = errorDetails;
    }

    #endregion

    public string[] ErrorDetails { get; }

}