namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public sealed class VariableSymbol : Symbol {

    #region Constructors declarations

    public VariableSymbol(string variableName, SymbolType variableType, IScope scope) : base(variableName, variableType, scope) { }

    #endregion

}