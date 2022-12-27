#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._5 {

    [UseReporter(typeof(BeyondCompareReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.R", 6, 5);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParseTree2.svg")]
        public void ajay_shah_b1_example() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("b1.R", 6, 5);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void ajay_shah_b5_example() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("b5.R", 6, 5);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

    }

}