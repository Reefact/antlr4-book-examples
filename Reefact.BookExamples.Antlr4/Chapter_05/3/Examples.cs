#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._3 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void example_01() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("a[1]");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree    = grun.ToLispStyleTree();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(expr a [ (expr 1) ])");
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParseTree2.svg")]
        public void example_02() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("(a[1])");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree    = grun.ToLispStyleTree();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(expr ( (expr a [ (expr 1) ]) ))");
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void example_03() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("(((1)))");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Check.That(output).IsEqualTo("(expr ( (expr ( (expr ( (expr 1) )) )) ))");
        }

    }

}