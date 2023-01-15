#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._4 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        [GraphicalTree("ParserTree1.svg")]
        public void basic_interpretation() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int    result           = grun.Eval();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(result).IsEqualTo(3);
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParserTree2.svg")]
        public void left_to_right_associativity_with_first_alternative_precedence_not_including_pow() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int    result           = grun.Eval();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(result).IsEqualTo(7);
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParserTree3.svg")]
        public void left_to_right_associativity() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1*2*3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int    result           = grun.Eval();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(result).IsEqualTo(6);
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        [GraphicalTree("ParserTree4.svg")]
        public void right_to_left_associativity() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1^2^3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int    result           = grun.Eval();
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Check.That(result).IsEqualTo(1);
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void first_alternative_precedence_including_pow() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("1+2*3+5*2^2+3");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            int result = grun.Eval();
            // Verify
            Check.That(result).IsEqualTo(30);
        }

    }

}