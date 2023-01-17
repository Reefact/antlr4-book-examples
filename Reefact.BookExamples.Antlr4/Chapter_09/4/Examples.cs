#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._4 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void valid_input() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("f(34);");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Check.That(lispStyleTree).IsEqualTo("(stat (fcall f ( (expr 34) )) ;)");
        }

        [Fact]
        public void missing_closure() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("f((34);");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

        [Fact]
        public void too_much_parentheses() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("f((34)));");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string lispStyleTree = grun.ToLispStyleTree();
            // Verify
            Approvals.Verify(lispStyleTree);
        }

    }

}