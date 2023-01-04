#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._4._1 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream, int indexOfTheColumnToDisplay) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            RowsLexer         lexer   = new(inputStream);
            CommonTokenStream tokens  = new(lexer);
            RowsParser        parser  = new(tokens, indexOfTheColumnToDisplay); // pass column number
            Action<Parser>    options = p => p.BuildParseTree = false;          // don't waste time building a tree

            return new GRun(lexer, tokens, parser, parser.file, options);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

        private new RowsParser Parser => (RowsParser)base.Parser;

        public IEnumerable<string> GetColumnRows() {
            return Parser.GetColumnRows();
        }

    }

}