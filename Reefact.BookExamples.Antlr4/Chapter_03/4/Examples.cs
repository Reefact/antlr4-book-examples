#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._4 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void to_unicode_string() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{99, 3, 451}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToUnicodeString();
            // Verify
            Check.That(output).IsEqualTo("\"\\u0063\\u0003\\u01c3\"");
        }

    }

}