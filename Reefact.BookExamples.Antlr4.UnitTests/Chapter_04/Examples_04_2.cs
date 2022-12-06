#region Usings declarations

using Antlr4.Runtime;

using Reefact.BookExamples.Antlr4.Chapter_04._2;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    public class Examples_04_2 {

        [Fact]
        public void evaluating_t_expr() {
            // Setup
            string           example     = ResourcesHelper.Read("Chapter_04.t_expr");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int[] results = grun.Eval();
            // Verify
            Check.That(results).CountIs(3);
            Check.That(results[0]).IsEqualTo(193);
            Check.That(results[1]).IsEqualTo(17);
            Check.That(results[2]).IsEqualTo(9);
        }

        [Fact]
        public void evaluating_c_expr() {
            // Setup
            string           example     = ResourcesHelper.Read("Chapter_04.c_expr");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int[] results = grun.Eval();
            // Verify
            Check.That(results).CountIs(4);
            Check.That(results[0]).IsEqualTo(5); // a (set)
            Check.That(results[1]).IsEqualTo(0); // b (unset)
            Check.That(results[2]).IsEqualTo(0); // a (clear)
            Check.That(results[3]).IsEqualTo(6); // b (set)
        }

    }

}