#region Usings declarations

using System.Text;

using Antlr4.Runtime;

using Reefact.BookExamples.Antlr4.Chapter_04._1._1;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    public class Examples_04_1_2 {

        [Fact]
        public void importing_grammar_style_works() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read($"3+4{Environment.NewLine}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr (expr 3) + (expr 4)) \\r\\n))");
        }

        [Fact]
        public void handle_erroneous_input() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("(1+2");
            example.AppendLine("3");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example.ToString());
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr ( (expr (expr 1) + (expr 2)) <missing ')'>) \\r\\n) (stat (expr 3) \\r\\n))");
        }

    }

}