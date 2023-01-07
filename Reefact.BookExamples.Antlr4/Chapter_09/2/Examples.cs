#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Atn;

using ApprovalTests;
using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    [UseReporter(typeof(BeyondCompareReporter), typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void verbose_listener() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T T { int ; }");
            SimpleGRun       grun        = SimpleGRun.Read(inputStream, new VerboseListener());
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void underline_listener() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("underline_listener.simple", 9, 2);
            SimpleGRun       grun        = SimpleGRun.Read(inputStream, new UnderlineListener());
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void ambiguity_not_detected() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("f();");
            AmbiguousGRun    grun        = AmbiguousGRun.Read(inputStream, new VerboseListener());
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Check.That(output).IsEmpty();
        }

        [Fact]
        public void ambiguity_detected() {
            // Setup
            AntlrInputStream        inputStream             = AntlrInputStreamReader.Read("f();");
            DiagnosticErrorListener diagnosticErrorListener = new();
            VerboseListener         verboseListener         = new();
            var                     errorListeners          = new BaseErrorListener[] { verboseListener, diagnosticErrorListener };

            static void Options(Parser parser) {
                parser.Interpreter.PredictionMode = PredictionMode.LL_EXACT_AMBIG_DETECTION;
            }

            AmbiguousGRun grun = AmbiguousGRun.Read(inputStream, Options, errorListeners);

            // Exercise
            string output = grun.GetOutput();

            // Verify
            Approvals.Verify(output);
        }

    }

}