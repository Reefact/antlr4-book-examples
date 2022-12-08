namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    public sealed class EvalVisitor : PLrABaseVisitor<int> {

        public int Result { get; private set; }

        /// <inheritdoc />
        public override int VisitCalc(PLrAParser.CalcContext context) {
            Result = Visit(context.expr());

            return Result;
        }

        public override int VisitInt(PLrAParser.IntContext context) {
            string intAsString = context.INT().GetText();
            int    value       = int.Parse(intAsString);

            return value;
        }

        /// <inheritdoc />
        public override int VisitPow(PLrAParser.PowContext context) {
            int left  = Visit(context.expr(0)); // get value of left subexpression
            int right = Visit(context.expr(1)); // get value of right subexpression

            return (int)Math.Pow(left, right);
        }

        public override int VisitMul(PLrAParser.MulContext context) {
            int left  = Visit(context.expr(0)); // get value of left subexpression
            int right = Visit(context.expr(1)); // get value of right subexpression

            return left * right;
        }

        public override int VisitAdd(PLrAParser.AddContext context) {
            int left  = Visit(context.expr(0)); // get value of left subexpression
            int right = Visit(context.expr(1)); // get value of right subexpression

            return left + right;
        }

    }

}