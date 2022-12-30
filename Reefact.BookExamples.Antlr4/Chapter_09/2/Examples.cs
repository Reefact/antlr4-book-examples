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
            AntlrInputStream inputStream   = AntlrInputStreamReader.Read("class T T { int : }");
            GRun             grun          = GRun.Read(inputStream);
            VerboseListener  errorListener = new();
            // Exercise
            string output = grun.GetOutput(errorListener);
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void underline_listener() {
            // Setup
            AntlrInputStream  inputStream   = AntlrInputStreamReader.Read("underline_listener.simple", 9, 2);
            GRun              grun          = GRun.Read(inputStream);
            UnderlineListener errorListener = new();
            // Exercise
            string output = grun.GetOutput(errorListener);
            // Verify
            Approvals.Verify(output);
        }

    }

}