#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Reefact.BookExamples.Antlr4.core;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._1 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void print_elements() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string result = grun.GetOutput();
            // Verify
            Check.That(result).IsEqualTo("var i\r\nclass T");
        }

        [Fact]
        public void printing_elements_in_a_bogus_assignment_expression() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("bogus_assignment_expression.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        [GraphicalTree("bogus_assignment_expression.simple.svg")]
        public void generating_mermaid_tree_style_in_a_bogus_assignment_expression() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("bogus_assignment_expression.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void printing_elements_when_error_consists_of_a_single_extra_token() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("single_extra_token.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        [GraphicalTree("single_extra_token.simple.svg")]
        public void generating_mermaid_tree_style_when_error_consists_of_a_single_extra_token() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("single_extra_token.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        [DubiousResult("Error mismatch",
                       "line 3:0 missing '}' at '<EOF>'",
                       "This seems to be caused by a new way of displaying the error as the Mermaid tree looks correct.")]
        public void printing_elements_when_parser_can_do_single_token_insertion() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("single_token_insertion.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        [GraphicalTree("single_token_insertion.simple.svg")]
        public void generating_mermaid_tree_style_when_parser_can_do_single_token_insertion() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("single_token_insertion.simple", 9, 1);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void printing_elements_when_no_viable_alternative() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T { int ; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void printing_elements_when_lexical_error() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class # { int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

    }

}