#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._1 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void Example() {
            // Setup
            GRun grun = GRun.ReadResource("t.properties", 7, 1);
            // Exercise
            string properties = grun.ToPropertiesString();
            // Verify
            Approvals.Verify(properties);
        }

    }

}