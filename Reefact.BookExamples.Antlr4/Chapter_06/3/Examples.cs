#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._3 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void tokens_tree() {
            // Setup
            GRun grun = GRun.ReadResource("t.dot", 6, 3);
            // Exercise
            string parseTree1 = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(parseTree1);
        }

    }

}