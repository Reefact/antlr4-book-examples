#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._1 {

    [UseReporter(typeof(BeyondCompareReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void Test() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.expr", 4, 1, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}