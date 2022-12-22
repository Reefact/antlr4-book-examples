#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._4 {

    public class Examples {

        [Fact]
        public void s_expr() {
            // Exercise
            Type sExprListenerType = typeof(ISExprListener);
            // Verify
            IEnumerable<string> methodsName = sExprListenerType.GetMethods().Select(m => m.Name);
            Check.That(methodsName).IsEquivalentTo("EnterS", "ExitS", "EnterE", "ExitE");
        }

        [Fact]
        public void l_expr() {
            // Exercise
            Type lExprListenerType = typeof(ILExprListener);
            // Verify
            IEnumerable<string> methodsName = lExprListenerType.GetMethods().Select(m => m.Name);
            Check.That(methodsName).IsEquivalentTo(
                "EnterS", "ExitS",
                "EnterAdd", "ExitAdd",
                "EnterMult", "ExitMult",
                "EnterInt", "ExitInt");
        }

    }

}