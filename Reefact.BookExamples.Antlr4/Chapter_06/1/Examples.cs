#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._1 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void Tree() {
            // Setup
            GRun grun = GRun.ReadResource("data.csv", 6, 1);
            // Exercise
            string listStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(listStyleTree);
        }

        [Fact]
        public void Tokens() {
            // Setup
            GRun grun = GRun.ReadResource("data.csv", 6, 1);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        public void MermaidTree() {
            // Setup
            GRun grun = GRun.ReadResource("data.csv", 6, 1);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}