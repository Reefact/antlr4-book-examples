#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._2 {

    public class Examples {

        [Fact]
        public void importing_grammar_style_works() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read($"3+4{Environment.NewLine}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(prog (stat (expr (expr 3) + (expr 4)) \\r\\n))");
        }

    }

}