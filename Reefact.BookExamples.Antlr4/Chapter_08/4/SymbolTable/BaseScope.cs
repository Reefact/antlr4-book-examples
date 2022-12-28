#region Usings declarations

using System.Diagnostics.CodeAnalysis;
using System.Text;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public abstract class BaseScope : IScope {

    #region Fields declarations

    private readonly IScope?                    _enclosingScope; // null if global (outermost) scope
    private readonly Dictionary<string, Symbol> _symbols = new();

    #endregion

    #region Constructors declarations

    public BaseScope(IScope? enclosingScope) {
        _enclosingScope = enclosingScope;
    }

    #endregion

    /// <inheritdoc />
    public abstract string Name { get; }

    /// <inheritdoc />
    public bool TryGetEnclosingScope([NotNullWhen(true)] out IScope? enclosingScope) {
        enclosingScope = _enclosingScope;

        return enclosingScope != null;
    }

    /// <inheritdoc />
    public FunctionSymbol DefineFunctionSymbol(string symbolName, SymbolType symbolType) {
        if (symbolName is null) { throw new ArgumentNullException(nameof(symbolName)); }

        FunctionSymbol functionSymbol = new(symbolName, symbolType, this);
        _symbols.Add(functionSymbol.Name, functionSymbol);

        return functionSymbol;
    }

    /// <inheritdoc />
    public VariableSymbol DefineVariableSymbol(string symbolName, SymbolType symbolType) {
        if (symbolName is null) { throw new ArgumentNullException(nameof(symbolName)); }

        VariableSymbol variableSymbol = new(symbolName, symbolType, this);
        _symbols.Add(variableSymbol.Name, variableSymbol);

        return variableSymbol;
    }

    /// <inheritdoc />
    public bool TryResolveSymbol(string symbolName, [NotNullWhen(true)] out Symbol? symbol) {
        if (_symbols.TryGetValue(symbolName, out symbol)) { return true; }
        if (_enclosingScope == null) { return false; }
        if (_enclosingScope.TryResolveSymbol(symbolName, out symbol)) { return true; }

        return false;
    }

    public override string ToString() {
        StringBuilder builder = new(Name);
        builder.Append(":[");
        if (_symbols.Count > 0) {
            builder.Append(_symbols.Keys.Aggregate((previous, next) => $"{previous}, {next}"));
        }
        builder.Append("]");

        return builder.ToString();
    }

}