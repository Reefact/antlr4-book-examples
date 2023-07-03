namespace Reefact.BookExamples.Antlr4.Chapter_08._1 {

    public sealed class CsvLoader : CSV_8_1BaseListener {

        #region Fields declarations

        // Load a list of row dictionaries that map field name to value
        private readonly List<Dictionary<string, string>> _rows = new();
        // List of column names
        private readonly List<string> _header = new();
        // Build up a list of fields in current row
        private readonly List<string> _currentRowFieldValues = new();

        #endregion

        /// <inheritdoc />
        public override void ExitString(CSV_8_1Parser.StringContext context) {
            string evaluatedString = context.STRING().GetText();

            _currentRowFieldValues.Add(evaluatedString);
        }

        /// <inheritdoc />
        public override void ExitText(CSV_8_1Parser.TextContext context) {
            string evaluatedText = context.TEXT().GetText();

            _currentRowFieldValues.Add(evaluatedText);
        }

        /// <inheritdoc />
        public override void ExitEmpty(CSV_8_1Parser.EmptyContext context) {
            _currentRowFieldValues.Add(string.Empty);
        }

        /// <inheritdoc />
        public override void ExitHdr(CSV_8_1Parser.HdrContext context) {
            _header.Clear();
            _header.AddRange(_currentRowFieldValues);
        }

        /// <inheritdoc />
        public override void EnterRow(CSV_8_1Parser.RowContext context) {
            _currentRowFieldValues.Clear();
        }

        /// <inheritdoc />
        public override void ExitRow(CSV_8_1Parser.RowContext context) {
            if (context.Parent.RuleIndex == CSV_8_1Parser.RULE_hdr) { return; }

            Dictionary<string, string> fields = new();
            int                        index  = 0;
            foreach (string fieldValue in _currentRowFieldValues) {
                string fieldName = _header[index++];
                fields.Add(fieldName, fieldValue);
            }
            _rows.Add(fields);
        }

        public List<Dictionary<string, string>> GetData() {
            return _rows;
        }

    }

}