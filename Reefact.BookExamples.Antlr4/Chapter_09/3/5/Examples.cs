#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_09._1;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._5 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void extra_int_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("extra_int.simple", 9, 3, 4);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void good_syntax_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void bad_syntax_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T { int int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}