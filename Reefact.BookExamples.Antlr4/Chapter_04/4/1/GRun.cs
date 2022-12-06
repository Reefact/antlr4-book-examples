#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._4._1 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream, int indexOfTheColumnToDisplay) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            RowsLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            RowsParser        parser = new(tokens, indexOfTheColumnToDisplay); // pass column number
            parser.BuildParseTree = false;                                     // don't waste time building a tree
            parser.file();                                                     // parse

            return new GRun(parser);
        }

        #endregion

        #region Fields declarations

        private readonly RowsParser _parser;

        #endregion

        #region Constructors declarations

        private GRun(RowsParser parser) {
            _parser = parser;
        }

        #endregion

        public IEnumerable<string> GetColumnRows() {
            return _parser.GetColumnRows();
        }

    }

}