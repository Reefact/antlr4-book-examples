namespace Reefact.BookExamples.Antlr4.core {

    /// <summary>
    ///     Indicates that the result of the test is dubious because of a difference with the book, but potentially possible
    ///     (eg. version difference, ...) but not explained for the moment.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DubiousResultAttribute : Attribute {

        #region Constructors declarations

        /// <inheritdoc />
        public DubiousResultAttribute(string problemDescription, string expectedResult, string comment = "") {
            if (problemDescription is null) { throw new ArgumentNullException(nameof(problemDescription)); }
            if (expectedResult is null) { throw new ArgumentNullException(nameof(expectedResult)); }

            ProblemDescription = problemDescription;
            ExpectedResult     = expectedResult;
            Comment            = comment ?? string.Empty;
        }

        #endregion

        /// <summary>Description of the problem.</summary>
        public string ProblemDescription { get; }

        /// <summary>The expected result.</summary>
        public string ExpectedResult { get; }

        /// <summary>Additional information on the problem.</summary>
        public string Comment { get; }

    }

}