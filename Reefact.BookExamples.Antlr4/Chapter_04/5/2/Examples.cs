#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._2 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            string           inputString = ResourcesHelper.Read("Demo.java", 4, 3);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(inputString);
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string output = grun.Rewrite();
            // Verify
            string expectedOutput = ResourcesHelper.Read("Demo_rewrited.java", 4, 5, 2);
            Check.That(output).IsEqualTo(expectedOutput);
        }

    }

}