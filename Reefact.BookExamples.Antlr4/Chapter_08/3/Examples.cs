#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void generate_call_graph() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.cymbol", 8, 3);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string result = grun.ToDot();
            // Verify
            Approvals.Verify(result);
        }

    }

}