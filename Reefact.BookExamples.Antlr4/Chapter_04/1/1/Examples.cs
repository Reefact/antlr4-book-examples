#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._1 {

    public class Examples {

        [Fact]
        public void Test() {
            // Setup
            GRun grun = GRun.ReadResource("t.expr", 4, 1, 1);
            // Exercise
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr 193) \\r\\n) (stat a = (expr 5) \\r\\n) (stat b = (expr 6) \\r\\n) (stat (expr (expr a) + (expr (expr b) * (expr 2))) \\r\\n) (stat (expr (expr ( (expr (expr 1) + (expr 2)) )) * (expr 3)) \\r\\n))");
        }

    }

}