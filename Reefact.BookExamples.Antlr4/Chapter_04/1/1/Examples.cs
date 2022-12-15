#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._1 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        [ExpectedParseTree(1)]
        public void Test() {
            // Setup
            GRun grun = GRun.ReadResource("t.expr", 4, 1, 1);
            // Exercise
            string parseTree1 = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(parseTree1);
        }

    }

}