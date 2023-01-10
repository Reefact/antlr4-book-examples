#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._4 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void vec_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1,2,3,4,5,6]");
            GRun             grun        = GRun.ReadVec(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

        [Fact]
        public void vec_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1,2,3,4,5,6]");
            GRun             grun        = GRun.ReadVec(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void vec_msg_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("[1,2,3,4,5,6]");
            GRun             grun        = GRun.ReadVecMsg(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

        [Fact]
        public void pred_ok_msg_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("val=1;");
            GRun             grun        = GRun.ReadPred(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(assign val = 1 ;)");
        }

        [Fact]
        public void pred_ko_msg_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("val=0;");
            GRun             grun        = GRun.ReadPred(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

    }

}