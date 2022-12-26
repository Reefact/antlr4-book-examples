#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._1 {

    public class Examples {

        [Fact]
        public void load() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("data.csv", 6, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            List<Dictionary<string, string>> result = grun.Load();
            // Verify
            List<Dictionary<string, string>> expectedResult = new();
            Dictionary<string, string> row1 = new() {
                { FieldName.Details, "Mid Bonus" },
                { FieldName.Month, "June" },
                { FieldName.Amount, "\"$2,000\"" }
            };
            expectedResult.Add(row1);
            Dictionary<string, string> row2 = new() {
                { FieldName.Details, "" },
                { FieldName.Month, "January" },
                { FieldName.Amount, "\"\"\"zippo\"\"\"" }
            };
            expectedResult.Add(row2);
            Dictionary<string, string> row3 = new() {
                { FieldName.Details, "Total Bonuses" },
                { FieldName.Month, "\"\"" },
                { FieldName.Amount, "\"$5,000\"" }
            };
            expectedResult.Add(row3);
            Check.That(result).IsEquivalentTo(expectedResult);
        }

        #region Nested types declarations

        private static class FieldName {

            public const string Details = "Details";
            public const string Month   = "Month";
            public const string Amount  = "Amount";

        }

        #endregion

    }

}