#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_04._5._2;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples_04_5_2 {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            string           inputString = ResourcesHelper.Read("Chapter_04.Demo.java");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(inputString);
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string output = grun.Rewrite();
            // Verify
            string expectedOutput = ResourcesHelper.Read("Chapter_04.Demo_rewrited.java");
            Check.That(output).IsEqualTo(expectedOutput);
        }

    }

}