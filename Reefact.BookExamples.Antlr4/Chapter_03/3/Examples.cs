#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._3 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void to_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{1,{2,3},4}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(init { (value 1) , (value (init { (value 2) , (value 3) })) , (value 4) })");
        }

        [Fact]
        public void to_lisp_style_tree_with_missing_brace() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{1,2");
            _2.GRun          grun        = _2.GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

    }

}