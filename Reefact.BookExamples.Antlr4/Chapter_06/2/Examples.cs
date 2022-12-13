#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._2 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void t_json() {
            // Setup
            GRun grun = GRun.ReadResource("t.json", 6, 2);
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        public void simple_array_tokens() {
            // Setup
            GRun grun = GRun.ReadString("[1,\"\\u0049\",1.3e9]");
            // Exercise
            string tokensString = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokensString);
        }

        [Fact]
        public void simple_array_tree() {
            // Setup
            GRun grun = GRun.ReadString("[1,\"\\u0049\",1.3e9]");
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

    }

}