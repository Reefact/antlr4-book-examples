#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void verbose_listener() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T T { int : }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

    }

}