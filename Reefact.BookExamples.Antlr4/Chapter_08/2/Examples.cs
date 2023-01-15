#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._2 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void translate() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.json", 8, 2);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string result = grun.Translate();
            // Verify
            Approvals.Verify(result);
        }

    }

}