#region Usings declarations

using Antlr4.Runtime;

using Reefact.BookExamples.Antlr4.Chapter_04._06;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    public class Examples_06 {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("2 9 10 3 1 2 3");
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(file (group 2 (sequence 9 10)) (group 3 (sequence 1 2 3)))");
        }

    }

}