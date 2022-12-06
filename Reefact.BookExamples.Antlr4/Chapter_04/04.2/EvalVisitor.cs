namespace Reefact.BookExamples.Antlr4.Chapter_04._03 {

    public sealed class EvalVisitor : LabeledExprBaseVisitor<int> {

        #region Fields declarations

        private readonly Dictionary<string, int> _memory  = new();
        private readonly List<int>               _results = new();

        #endregion

        // ID '=' expr NEWLINE
        public override int VisitAssign(LabeledExprParser.AssignContext context) {
            string id    = context.ID().GetText(); // id is left-hand side of '='
            int    value = Visit(context.expr());  // compute value of expression on right
            // store id in memory
            if (_memory.ContainsKey(id)) {
                _memory[id] = value;
            } else {
                _memory.Add(id, value);
            }

            return value;
        }

        // expr NEWLINE
        public override int VisitPrintExpr(LabeledExprParser.PrintExprContext context) {
            int value = Visit(context.expr()); // evaluate the child expr 
            _results.Add(value);

            return 0;
        }

        // '$' command NEWLINE
        public override int VisitCmd(LabeledExprParser.CmdContext context) {
            return Visit(context.command());
        }

        // INT
        public override int VisitInt(LabeledExprParser.IntContext context) {
            string intAsString = context.INT().GetText();
            int    value       = int.Parse(intAsString);

            return value;
        }

        // ID
        public override int VisitId(LabeledExprParser.IdContext context) {
            string id = context.ID().GetText();
            if (_memory.TryGetValue(id, out int value)) { return value; }

            return 0;
        }

        // expr op=('*'|'/') expr
        public override int VisitMulDiv(LabeledExprParser.MulDivContext context) {
            int left  = Visit(context.expr(0)); // get value of left subexpression
            int right = Visit(context.expr(1)); // get value of right subexpression
            if (context.op.Type == LabeledExprParser.MUL) { return left * right; }

            return left / right;
        }

        // expr op=('+'|'-') expr
        public override int VisitAddSub(LabeledExprParser.AddSubContext context) {
            int left  = Visit(context.expr(0)); // get value of left subexpression
            int right = Visit(context.expr(1)); // get value of right subexpression
            if (context.op.Type == LabeledExprParser.ADD) { return left + right; }

            return left - right;
        }

        // '(' expr ')'
        public override int VisitParens(LabeledExprParser.ParensContext context) {
            return Visit(context.expr()); // return child expr's value
        }

        // clear
        public override int VisitClear(LabeledExprParser.ClearContext context) {
            _memory.Clear();

            return 0;
        }

        public IEnumerable<int> GetResults() {
            return _results;
        }

    }

}