#region Usings declarations

using ApprovalTests.Reporters;

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4 {

    internal class CustomReporter : FirstWorkingReporter {

        #region Constructors declarations

        public CustomReporter() : base(new BeyondCompareReporter(), new KDiff3Reporter(), new VisualStudioReporter()) { }

        #endregion

    }

}