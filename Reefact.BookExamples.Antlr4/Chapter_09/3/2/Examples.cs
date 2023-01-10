#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_09._1;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._2 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void extraneous_input_9_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class 9 T { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void extraneous_input_9_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class 9 T { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void missing_ID_lisp_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void missing_ID_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void missing_ID_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

    }

}