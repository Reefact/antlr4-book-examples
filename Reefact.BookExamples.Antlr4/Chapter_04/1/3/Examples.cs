#region Usings declarations

using System.Text;

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_04._1._2;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._1._3 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void lisp_style_tree_example() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("(1+2");
            example.AppendLine("3");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example);
            // Exercise
            GRun   grun          = GRun.Read(inputStream);
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void mermaid_style_tree_example() {
            // Setup
            StringBuilder example = new();
            example.AppendLine("(1+2");
            example.AppendLine("34*69");
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(example);
            // Exercise
            GRun   grun             = GRun.Read(inputStream);
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}