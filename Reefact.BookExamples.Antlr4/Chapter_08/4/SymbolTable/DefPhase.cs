#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable {

    public sealed class DefPhase : Cymbol_8_4BaseListener {

        #region Fields declarations

        private readonly List<IScope> _scopes = new();

        private IScope _currentScope;

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public DefPhase() {
            GlobalScope   = new GlobalScope();
            _currentScope = GlobalScope;
        }

        #endregion

        public ParseTreeProperty<IScope> Scopes      { get; } = new();
        public GlobalScope               GlobalScope { get; private set; }

        /// <inheritdoc />
        public override void EnterFile(Cymbol_8_4Parser.FileContext context) {
            GlobalScope   = new GlobalScope();
            _currentScope = GlobalScope;
            _scopes.Clear();
        }

        /// <inheritdoc />
        public override void ExitFile(Cymbol_8_4Parser.FileContext context) {
            _scopes.Add(GlobalScope);
        }

        /// <inheritdoc />
        public override void EnterFunctionDecl(Cymbol_8_4Parser.FunctionDeclContext context) {
            string         functionName = context.ID().GetText();
            SymbolType     functionType = SymbolTypeConverter.Convert(context.Start.Type);
            FunctionSymbol function     = _currentScope.DefineFunctionSymbol(functionName, functionType); // Define function in current scope
            Scopes.Put(context, function);                                                                // Push: set function's parent to current
            _currentScope = function;                                                                     // Current scope is now function scope
        }

        public override void ExitFunctionDecl(Cymbol_8_4Parser.FunctionDeclContext context) {
            _scopes.Add(_currentScope);
            PopScope();
        }

        public override void EnterBlock(Cymbol_8_4Parser.BlockContext context) {
            _currentScope = new LocalScope(_currentScope);
            Scopes.Put(context, _currentScope);
        }

        public override void ExitBlock(Cymbol_8_4Parser.BlockContext context) {
            _scopes.Add(_currentScope);
            PopScope();
        }

        public override void ExitFormalParameter(Cymbol_8_4Parser.FormalParameterContext context) {
            DefineVariable(context.type(), context.ID().Symbol);
        }

        public override void ExitVarDecl(Cymbol_8_4Parser.VarDeclContext context) {
            DefineVariable(context.type(), context.ID().Symbol);
        }

        public IEnumerable<IScope> GetScopes() {
            return _scopes;
        }

        private void PopScope() {
            if (!_currentScope.TryGetEnclosingScope(out IScope? enclosingScope)) { throw new Exception("Cannot pop scope."); }

            _currentScope = enclosingScope;
        }

        private void DefineVariable(Cymbol_8_4Parser.TypeContext context, IToken variableNameToken) {
            SymbolType type = SymbolTypeConverter.Convert(context.Start.Type);
            _currentScope.DefineVariableSymbol(variableNameToken.Text, type);
        }

    }

}