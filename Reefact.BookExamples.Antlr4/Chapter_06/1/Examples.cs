#region Usings declarations

using Antlr4.Runtime;

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
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("data.csv", 6, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string listStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(listStyleTree);
        }

        [Fact]
        public void Tokens() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("data.csv", 6, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        public void MermaidTree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("data.csv", 6, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}