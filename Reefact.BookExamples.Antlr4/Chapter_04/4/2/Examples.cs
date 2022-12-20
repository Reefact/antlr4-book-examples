#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._4._2 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("2 9 10 3 1 2 3");
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string lispStyleTree    = grun.ToLispStyleTree();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(file (group 2 (sequence 9 10)) (group 3 (sequence 1 2 3)))");
            Approvals.Verify(mermaidStyleTree);
        }

    }

}