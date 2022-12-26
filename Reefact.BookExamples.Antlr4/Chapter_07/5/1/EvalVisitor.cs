#region Usings declarations

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._1 {

    public class EvalVisitor : LExprBaseVisitor<int> {

        /// <inheritdoc />
        public override int VisitMult(LExprParser.MultContext context) {
            LExprParser.EContext leftExpression  = context.e(0);
            int                  leftValue       = Visit(leftExpression);
            LExprParser.EContext rightExpression = context.e(1);
            int                  rightValue      = Visit(rightExpression);

            return leftValue * rightValue;
        }

        /// <inheritdoc />
        public override int VisitAdd(LExprParser.AddContext context) {
            LExprParser.EContext leftExpression  = context.e(0);
            int                  leftValue       = Visit(leftExpression);
            LExprParser.EContext rightExpression = context.e(1);
            int                  rightValue      = Visit(rightExpression);

            return leftValue + rightValue;
        }

        /// <inheritdoc />
        public override int VisitInt(LExprParser.IntContext context) {
            ITerminalNode integerNode      = context.INT();
            string        integerAsString  = integerNode.GetText();
            int           evaluatedInteger = int.Parse(integerAsString);

            return evaluatedInteger;
        }

    }

}