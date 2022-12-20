#region Usings declarations

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

    }

}