#region Usings declarations

using System.Text;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._2 {

    public class Examples {

        [Fact]
        public void importing_grammar_style_works() {
            // Setup
            GRun grun = GRun.ReadString($"3+4{Environment.NewLine}");
            // Exercise
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr (expr 3) + (expr 4)) \\r\\n))");
        }

        [Fact]
        public void handle_erroneous_input() {
            // Setup
            StringBuilder exampleBuilder = new();
            exampleBuilder.AppendLine("(1+2");
            exampleBuilder.AppendLine("3");
            var example = exampleBuilder.ToString();

            GRun grun = GRun.ReadString(example);
            // Exercise
            string lispTree    = grun.ToLispStyleTree();
            string mermaidTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr ( (expr (expr 1) + (expr 2)) <missing ')'>) \\r\\n) (stat (expr 3) \\r\\n))");
        }

    }

}