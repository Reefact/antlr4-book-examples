#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    public class Examples {

        [Fact]
        public void basic_interpretation() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(3);
        }

        [Fact]
        public void left_to_right_associativity_with_first_alternative_precedence_not_including_pow() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(7);
        }

        [Fact]
        public void right_to_left_associativity() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1^2^3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(1);
        }

        [Fact]
        public void first_alternative_precedence_including_pow() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3+5*2^2+3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(30);
        }

    }

}