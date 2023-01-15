#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void mermaid_tree_style_of_t_properties() {
            // Setup
            AntlrInputStream stream = AntlrInputStreamReader.Read("t.properties", 7, 3);
            GRun             grun   = GRun.Read(stream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void load_t_properties() {
            // Setup
            AntlrInputStream stream = AntlrInputStreamReader.Read("t.properties", 7, 3);
            GRun             grun   = GRun.Read(stream);
            // Exercise
            string properties = grun.ToPropertiesString();
            // Verify
            Approvals.Verify(properties);
        }

    }

}