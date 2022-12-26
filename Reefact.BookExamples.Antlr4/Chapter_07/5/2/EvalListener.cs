#region Usings declarations

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._2 {

    public sealed class EvalListener : LExprBaseListener {

        #region Fields declarations

        private readonly Stack<int> _stack = new();

        #endregion

        /// <inheritdoc />
        public override void ExitMult(LExprParser.MultContext context) {
            int right                   = _stack.Pop();
            int left                    = _stack.Pop();
            int evaluatedMultiplication = left * right;

            _stack.Push(evaluatedMultiplication);
        }

        /// <inheritdoc />
        public override void ExitAdd(LExprParser.AddContext context) {
            int right             = _stack.Pop();
            int left              = _stack.Pop();
            int evaluatedAddition = left + right;

            _stack.Push(evaluatedAddition);
        }

        /// <inheritdoc />
        public override void ExitInt(LExprParser.IntContext context) {
            ITerminalNode integerNode      = context.INT();
            string        integerAsString  = integerNode.GetText();
            int           evaluatedInteger = int.Parse(integerAsString);

            _stack.Push(evaluatedInteger);
        }

        public int Eval() {
            return _stack.Pop();
        }

    }

}