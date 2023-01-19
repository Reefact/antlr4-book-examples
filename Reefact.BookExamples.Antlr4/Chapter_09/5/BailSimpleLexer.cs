#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    public sealed class BailSimpleLexer : SimpleLexer {

        #region Constructors declarations

        /// <inheritdoc />
        public BailSimpleLexer(ICharStream input) : base(input) { }

        /// <inheritdoc />
        public BailSimpleLexer(ICharStream input, TextWriter output, TextWriter errorOutput) : base(input, output, errorOutput) { }

        #endregion

        /// <inheritdoc />
        public override void Recover(LexerNoViableAltException e) {
            throw new CustomLexerException(e.Message, e);
        }

    }

}