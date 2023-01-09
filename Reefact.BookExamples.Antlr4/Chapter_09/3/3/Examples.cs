#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_09._1;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._3 {

    [UseReporter(typeof(BeyondCompareReporter))]
    public class Examples {

        [Fact]
        public void single_token_deletion_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T {{ int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void single_token_deletion_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T {{ int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

    }

}