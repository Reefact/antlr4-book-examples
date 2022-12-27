#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._1 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.xml", 4, 5, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string[] tokens = grun.GetTokens();
            // Verify
            Approvals.VerifyAll(tokens, "");
        }

    }

}