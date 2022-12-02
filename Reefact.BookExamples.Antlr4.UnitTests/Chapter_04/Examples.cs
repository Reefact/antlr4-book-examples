#region Usings declarations

using Antlr4.Runtime;

using Reefact.BookExamples.Antlr4.Chapter_04;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    public class Examples {

        [Fact]
        public void Test() {
            // Setup
            string           example     = ResourcesHelper.Read("Chapter_04.t_expr");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr 193) \\r\\n) (stat a = (expr 5) \\r\\n) (stat b = (expr 6) \\r\\n) (stat (expr (expr a) + (expr (expr b) * (expr 2))) \\r\\n) (stat (expr (expr ( (expr (expr 1) + (expr 2)) )) * (expr 3)) \\r\\n))");
        }

    }

}