#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void convert_a_short_array_to_unicode_string() {
            // Setup
            GRun grun = GRun.ReadString("{99,3,451}");
            // Exercise
            string unicodeString = grun.ToUnicodeString();
            // Verify
            Check.That(unicodeString).IsEqualTo("\"\\u0063\\u0003\\u01C3\"");
        }

        [Fact]
        public void provide_a_lisp_tree_representation_of_a_short_array_in_ArrayInit_grammar() {
            // Setup
            GRun grun = GRun.ReadString("{99,3,451}");
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(init { (value 99) , (value 3) , (value 451) })");
        }

        [Fact]
        [GraphicalTree("ParseTree1.svg")]
        public void provide_mermaid_style_tree_representation_of_a_short_array_in_ArrayInit_grammar_for_nested_arrays() {
            // Setup
            GRun grun = GRun.ReadString("{1,{2,3},4}");
            // Exercise
            string parseTree1 = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(parseTree1);
        }

    }

}