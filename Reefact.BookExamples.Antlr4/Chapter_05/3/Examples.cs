#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._3 {

    public class Examples {

        [Fact]
        public void example_01() {
            // Setup
            GRun grun = GRun.ReadString("a[1]");
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr a [ (expr 1) ])");
        }

        [Fact]
        public void example_02() {
            // Setup
            GRun grun = GRun.ReadString("(a[1])");
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr ( (expr a [ (expr 1) ]) ))");
        }

        [Fact]
        public void example_03() {
            // Setup
            GRun grun = GRun.ReadString("(((1)))");
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr ( (expr ( (expr ( (expr 1) )) )) ))");
        }

    }

}