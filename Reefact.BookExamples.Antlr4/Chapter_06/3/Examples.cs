#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._3 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void tokens_graph() {
            // Setup
            GRun grun = GRun.ReadResource("t.dot", 6, 3);
            // Exercise
            string graph = grun.ToMermaidStyleGraph();
            // Verify
            Approvals.Verify(graph);
        }

    }

}