#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    public class Examples {

        [Fact]
        public void basic_interpretation() {
            // Setup
            GRun grun = GRun.ReadString("1+2");
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(3);
        }

        [Fact]
        public void left_to_right_associativity_with_first_alternative_precedence_not_including_pow() {
            // Setup
            GRun grun = GRun.ReadString("1+2*3");
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(7);
        }

        [Fact]
        public void right_to_left_associativity() {
            // Setup
            GRun grun = GRun.ReadString("1^2^3");
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(1);
        }

        [Fact]
        public void first_alternative_precedence_including_pow() {
            // Setup
            GRun grun = GRun.ReadString("1+2*3+5*2^2+3");
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(30);
        }

    }

}