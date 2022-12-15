namespace Reefact.BookExamples.Antlr4 {

    /// <summary>Indicates that a SVG visualization of the parse tree is available in local resources.</summary>
    public sealed class ExpectedParseTreeAttribute : Attribute {

        #region Constructors declarations

        public ExpectedParseTreeAttribute(int localIdentifier) {
            if (localIdentifier <= 0) { throw new ArgumentOutOfRangeException(nameof(localIdentifier)); }

            LocalIdentifier = localIdentifier;
        }

        #endregion

        public int LocalIdentifier { get; }

    }

}