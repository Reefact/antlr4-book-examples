#region Usings declarations

using System.Text;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Reefact.BookExamples.Antlr4.Chapter_04._1._2;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._3 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void lisp_style_tree_example() {
            // Setup
            StringBuilder exampleBuilder = new();
            exampleBuilder.AppendLine("(1+2");
            exampleBuilder.AppendLine("3");
            var example = exampleBuilder.ToString();
            // Exercise
            GRun   grun     = GRun.ReadString(example);
            string lispTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispTree).IsEqualTo("(prog (stat (expr ( (expr (expr 1) + (expr 2)) <missing ')'>) \\r\\n) (stat (expr 3) \\r\\n))");
        }

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void mermaid_style_tree_example() {
            // Setup
            StringBuilder exampleBuilder = new();
            exampleBuilder.AppendLine("(1+2");
            exampleBuilder.AppendLine("34*69");
            var example = exampleBuilder.ToString();
            // Exercise
            GRun   grun       = GRun.ReadString(example);
            string parseTree1 = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(parseTree1);
        }

    }

}