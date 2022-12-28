#region Usings declarations

using System.Diagnostics.CodeAnalysis;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public interface IScope {

    string Name { get; }

    FunctionSymbol DefineFunctionSymbol(string symbolName, SymbolType symbolType);
    VariableSymbol DefineVariableSymbol(string symbolName, SymbolType symbolType);

    bool TryResolveSymbol(string symbolName, [NotNullWhen(true)] out Symbol? symbol);

    bool TryGetEnclosingScope([NotNullWhen(true)] out IScope? enclosingScope);

}