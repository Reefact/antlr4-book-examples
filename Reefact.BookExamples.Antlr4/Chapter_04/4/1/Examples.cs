#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._4._1 {

    public class Examples {

        [Fact]
        public void display_column_of_index_0() {
            // Setup
            string           t_rows      = ResourcesHelper.Read("t.rows", 4, 4, 1);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(t_rows);
            GRun             grun        = GRun.Read(inputStream, 0);
            // Exercise
            string[] columnRows = grun.GetColumnRows().ToArray();
            // Verify
            Check.That(columnRows).CountIs(3);
            Check.That(columnRows).ContainsExactly("parrt", "tombu", "bke");
        }

        [Fact]
        public void display_column_of_index_1() {
            // Setup
            string           t_rows      = ResourcesHelper.Read("t.rows", 4, 4, 1);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(t_rows);
            GRun             grun        = GRun.Read(inputStream, 1);
            // Exercise
            string[] columnRows = grun.GetColumnRows().ToArray();
            // Verify
            Check.That(columnRows).CountIs(3);
            Check.That(columnRows).ContainsExactly("Terence Parr", "Tom Burns", "Kevin Edgar");
        }

        [Fact]
        public void display_column_of_index_2() {
            // Setup
            string           t_rows      = ResourcesHelper.Read("t.rows", 4, 4, 1);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(t_rows);
            GRun             grun        = GRun.Read(inputStream, 2);
            // Exercise
            string[] columnRows = grun.GetColumnRows().ToArray();
            // Verify
            Check.That(columnRows).CountIs(3);
            Check.That(columnRows).ContainsExactly("101", "020", "008");
        }

    }

}