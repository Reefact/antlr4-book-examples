namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public sealed class ProcessResult {

    #region Constructors declarations

    public ProcessResult(IEnumerable<string> errorMessages) {
        ErrorMessages = errorMessages.ToArray();
    }

    #endregion

    public string[] ErrorMessages { get; }

    public bool HasError   => ErrorMessages.Length > 0;
    public bool HasNoError => ErrorMessages.Length == 0;

}