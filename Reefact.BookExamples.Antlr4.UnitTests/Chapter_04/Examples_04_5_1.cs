#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_04._5._1;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples_04_5_1 {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            string           t_rows      = ResourcesHelper.Read("Chapter_04.t_xml");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(t_rows);
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string[] tokens = grun.GetTokens();
            // Verify
            Approvals.VerifyAll(tokens, "");
        }

    }

}