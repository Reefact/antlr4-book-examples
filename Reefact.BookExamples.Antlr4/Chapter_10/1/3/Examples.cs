#region Usings declarations

using System.Text;

using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_10._1._3 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void get_the_value_of_an_undefined_ID() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("x");
            // Exercise
            IEnumerable<int> result = Calc.Read(example.ToString());
            // Verify
            Check.That(result).ContainsExactly(0);
        }

        [Fact]
        public void get_the_value_of_a_defined_ID() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("x = 1");
            example.AppendLine("x");
            // Exercise
            IEnumerable<int> result = Calc.Read(example.ToString());
            // Verify
            Check.That(result).ContainsExactly(1);
        }

        [Fact]
        public void basic_calculation() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("x = 1");
            example.AppendLine("x");
            example.AppendLine("x+2*3");
            // Exercise
            IEnumerable<int> result = Calc.Read(example.ToString());
            // Verify
            Check.That(result).ContainsExactly(1, 7);
        }

        [Fact]
        public void some_calculations() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("x = 1");
            example.AppendLine("y = 4");
            example.AppendLine("z = (x+y)*2");
            example.AppendLine("z");
            example.AppendLine("g = x*(y+1)");
            example.AppendLine("g");
            example.AppendLine("h = g+y*(z+1)-7*x");
            example.AppendLine("h");
            // Exercise
            IEnumerable<int> result = Calc.Read(example.ToString());
            // Verify
            Check.That(result).ContainsExactly(10, 5, 42);
        }

    }

}