#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._1 {

    [UseReporter(typeof(BeyondCompareReporter))]
    public class Examples {

        [Fact]
        public void Example() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("t.properties", 7, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string properties = grun.ToPropertiesString();
            // Verify
            Approvals.Verify(properties);
        }

    }

}