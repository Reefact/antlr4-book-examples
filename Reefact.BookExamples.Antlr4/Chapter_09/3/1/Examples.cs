#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._1 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("good_syntax.svg")]
        public void good_syntax() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1^2]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("bad_syntax.svg")]
        public void bad_syntax() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}