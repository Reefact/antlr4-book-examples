#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._5._3 {

    public class Examples {

        [Fact]
        public void evaluation() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(7);
        }

        [Fact]
        public void lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(s (e (e 1) + (e (e 2) * (e 3))))");
        }

    }

}