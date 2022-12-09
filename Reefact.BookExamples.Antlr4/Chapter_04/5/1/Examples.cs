#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._1 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            GRun grun = GRun.ReadResource("t.xml", 4, 5, 1);
            // Exercise
            string[] tokens = grun.GetTokens();
            // Verify
            Approvals.VerifyAll(tokens, "");
        }

    }

}