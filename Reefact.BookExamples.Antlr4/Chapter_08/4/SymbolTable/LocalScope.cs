namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public class LocalScope : BaseScope {

    #region Constructors declarations

    public LocalScope(IScope parent) : base(parent) { }

    #endregion

    /// <inheritdoc />
    public override string Name => "locals";

}