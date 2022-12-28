#region Usings declarations

using System.Diagnostics.CodeAnalysis;
using System.Text;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable {

    public sealed class FunctionSymbol : Symbol, IScope {

        #region Fields declarations

        private readonly Dictionary<string, Symbol> _arguments = new();

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public FunctionSymbol(string name, SymbolType type, IScope scope) : base(name, type, scope) { }

        #endregion

        /// <inheritdoc />
        public bool TryGetEnclosingScope([NotNullWhen(true)] out IScope? enclosingScope) {
            enclosingScope = Scope;

            return true;
        }

        /// <inheritdoc />
        public FunctionSymbol DefineFunctionSymbol(string symbolName, SymbolType symbolType) {
            if (symbolName is null) { throw new ArgumentNullException(nameof(symbolName)); }

            FunctionSymbol symbol = new(symbolName, symbolType, this);
            _arguments.Add(symbol.Name, symbol);

            return symbol;
        }

        /// <inheritdoc />
        public VariableSymbol DefineVariableSymbol(string symbolName, SymbolType symbolType) {
            if (symbolName is null) { throw new ArgumentNullException(nameof(symbolName)); }

            VariableSymbol symbol = new(symbolName, symbolType, this);
            _arguments.Add(symbolName, symbol);

            return symbol;
        }

        /// <inheritdoc />
        public bool TryResolveSymbol(string symbolName, [NotNullWhen(true)] out Symbol? symbol) {
            if (_arguments.TryGetValue(symbolName, out symbol)) { return true; }
            if (Scope.TryResolveSymbol(symbolName, out symbol)) { return true; }

            return false;
        }

        /// <inheritdoc />
        public override string ToString() {
            StringBuilder builder = new("function");
            builder.Append(base.ToString());
            builder.Append(":[");
            if (_arguments.Count > 0) {
                builder.Append(_arguments.Values.Select(s => s.ToString()).Aggregate((previous, next) => $"{previous}, {next}"));
            }
            builder.Append("]");

            return builder.ToString();
        }

    }

}