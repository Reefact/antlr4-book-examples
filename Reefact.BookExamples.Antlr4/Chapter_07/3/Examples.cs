#region Usings declarations

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void mermaid_tree_style_of_t_properties() {
            // Setup
            GRun grun = GRun.ReadResource("t.properties", 7, 3);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void load_t_properties() {
            // Setup
            GRun grun = GRun.ReadResource("t.properties", 7, 3);
            // Exercise
            string properties = grun.ToPropertiesString();
            // Verify
            Approvals.Verify(properties);
        }

    }

}