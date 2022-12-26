#region Usings declarations

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._3 {

    public sealed class EvalListenerWithProps : LExprBaseListener {

        #region Fields declarations

        private readonly ParseTreeProperty<int> _values = new();
        private          int                    _result;

        #endregion

        /// <inheritdoc />
        public override void ExitInt(LExprParser.IntContext context) {
            ITerminalNode integerNode      = context.INT();
            string        integerAsString  = integerNode.GetText();
            int           evaluatedInteger = int.Parse(integerAsString);

            _values.Put(context, evaluatedInteger);
        }

        /// <inheritdoc />
        public override void ExitAdd(LExprParser.AddContext context) {
            int left              = _values.Get(context.e(0));
            int right             = _values.Get(context.e(1));
            int evaluatedAddition = left + right;

            _values.Put(context, evaluatedAddition);
        }

        /// <inheritdoc />
        public override void ExitMult(LExprParser.MultContext context) {
            int left                    = _values.Get(context.e(0));
            int right                   = _values.Get(context.e(1));
            int evaluatedMultiplication = left * right;

            _values.Put(context, evaluatedMultiplication);
        }

        /// <inheritdoc />
        public override void ExitS(LExprParser.SContext context) {
            _result = _values.Get(context.e());
        }

        public int Eval() {
            return _result;
        }

    }

}