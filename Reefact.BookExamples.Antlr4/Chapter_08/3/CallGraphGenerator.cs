namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    public sealed class CallGraphGenerator : Cymbol_8_3BaseListener {

        #region Fields declarations

        private readonly CallGraph _callGraph = new();

        private NodeName? _currentNodeName;

        #endregion

        /// <inheritdoc />
        public override void EnterFunctionDecl(Cymbol_8_3Parser.FunctionDeclContext context) {
            _currentNodeName = new NodeName(context.ID().GetText());

            _callGraph.AddNode(_currentNodeName);
        }

        /// <inheritdoc />
        public override void ExitCall(Cymbol_8_3Parser.CallContext context) {
            NodeName nodeName = new(context.ID().GetText());

            _callGraph.AddEdge(_currentNodeName!, nodeName);
        }

        public string ToDot() {
            return _callGraph.ToDot();
        }

    }

}