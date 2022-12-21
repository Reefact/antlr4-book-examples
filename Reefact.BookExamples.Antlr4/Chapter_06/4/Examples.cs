#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_06._4 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void mermaid_style_tree() {
            // Setup
            GRun grun = GRun.ReadResource("t.cymbol", 6, 4);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParseTree2.svg")]
        public void precedence_01() {
            // Setup
            GRun grun = GRun.ReadString("int a = -x+y;");
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParseTree3.svg")]
        public void precedence_02() {
            // Setup
            GRun grun = GRun.ReadString("float b = -a[i];");
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}