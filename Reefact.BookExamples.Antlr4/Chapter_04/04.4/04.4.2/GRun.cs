#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._06 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream, int indexOfTheColumnToDisplay) {
            if (inputStream is null) { throw new ArgumentNullException(nameof(inputStream)); }

            DataLexer         lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            DataParser        parser = new(tokens);
            IParseTree        tree   = parser.file();

            return new GRun(tree, parser);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(IParseTree tree, Parser parser) : base(tree, parser) { }

        #endregion

    }

}