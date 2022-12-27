#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._2 {

    [UseReporter(typeof(BeyondCompareReporter))]
    public class Examples {

        [Fact]
        public void t_json_tokensString() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.json", 6, 2);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void t_json_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.json", 6, 2);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void simple_array_tokens() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1,\"\\u0049\",1.3e9]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        public void simple_array_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1,\"\\u0049\",1.3e9]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

    }

}