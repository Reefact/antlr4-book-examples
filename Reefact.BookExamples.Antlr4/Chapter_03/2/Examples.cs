#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._2 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void to_tokens_string() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{99, 3, 451}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string tokens = grun.ToTokensString();
            // Verify
            Approvals.Verify(tokens);
        }

        [Fact]
        public void provide_a_lisp_tree_representation_of_a_short_array_in_ArrayInit_grammar() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{99, 3, 451}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(init { (value 99) , (value 3) , (value 451) })");
        }

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void provide_mermaid_style_tree_representation_of_a_short_array_in_ArrayInit_grammar_for_nested_arrays() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("{1,{2,3},4}");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

    }

}