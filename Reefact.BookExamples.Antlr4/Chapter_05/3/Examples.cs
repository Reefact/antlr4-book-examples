#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._3 {

    public class Examples {

        [Fact]
        public void example_01() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("a[1]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr a [ (expr 1) ])");
        }

        [Fact]
        public void example_02() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("(a[1])");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr ( (expr a [ (expr 1) ]) ))");
        }

        [Fact]
        public void example_03() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("(((1)))");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr ( (expr ( (expr ( (expr 1) )) )) ))");
        }

    }

}