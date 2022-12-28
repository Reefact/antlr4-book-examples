#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable {

    public sealed class RefPhase : Cymbol_8_4BaseListener {

        #region Fields declarations

        private readonly List<string> _errorMessages = new();

        private readonly ParseTreeProperty<IScope> _scopes;
        private readonly GlobalScope               _globalScope;

        private IScope _currentScope;

        #endregion

        #region Constructors declarations

        public RefPhase(GlobalScope globalScope, ParseTreeProperty<IScope> scopes) {
            if (globalScope is null) { throw new ArgumentNullException(nameof(globalScope)); }
            if (scopes is null) { throw new ArgumentNullException(nameof(scopes)); }

            _scopes       = scopes;
            _globalScope  = globalScope;
            _currentScope = globalScope;
        }

        #endregion

        public override void EnterFile(Cymbol_8_4Parser.FileContext context) {
            _currentScope = _globalScope;
        }

        public override void EnterFunctionDecl(Cymbol_8_4Parser.FunctionDeclContext context) {
            _currentScope = _scopes.Get(context);
        }

        public override void ExitFunctionDecl(Cymbol_8_4Parser.FunctionDeclContext context) {
            PopScope();
        }

        public override void EnterBlock(Cymbol_8_4Parser.BlockContext context) {
            _currentScope = _scopes.Get(context);
        }

        public override void ExitBlock(Cymbol_8_4Parser.BlockContext context) {
            PopScope();
        }

        public override void ExitVar(Cymbol_8_4Parser.VarContext context) {
            string variableName = context.ID().Symbol.Text;
            if (!_currentScope.TryResolveSymbol(variableName, out Symbol? varSymbol)) {
                AppendError(context.ID().Symbol, "no such variable: " + variableName);
            }
            if (varSymbol is FunctionSymbol) {
                AppendError(context.ID().Symbol, variableName + " is not a variable");
            }
        }

        public override void ExitCall(Cymbol_8_4Parser.CallContext context) {
            string functionName = context.ID().GetText();
            if (!_currentScope.TryResolveSymbol(functionName, out Symbol? functionSymbol)) {
                AppendError(context.ID().Symbol, $"no such function: {functionName}");
            }
            if (functionSymbol is VariableSymbol) {
                AppendError(context.ID().Symbol, $"{functionName} is not a function");
            }
        }

        public IEnumerable<string> GetErrors() {
            return _errorMessages;
        }

        private void AppendError(IToken t, string message) {
            _errorMessages.Add($"line {t.Line}:{t.Column} {message}");
        }

        private void PopScope() {
            if (!_currentScope.TryGetEnclosingScope(out IScope? enclosingScope)) { throw new Exception("Cannot pop scope."); }

            _currentScope = enclosingScope;
        }

    }

}