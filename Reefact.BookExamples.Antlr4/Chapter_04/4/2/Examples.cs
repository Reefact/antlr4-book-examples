#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._4._2 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("2 9 10 3 1 2 3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void lisp_tree_style() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("2 9 10 3 1 2 3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(file (group 2 (sequence 9 10)) (group 3 (sequence 1 2 3)))");
        }

    }

}