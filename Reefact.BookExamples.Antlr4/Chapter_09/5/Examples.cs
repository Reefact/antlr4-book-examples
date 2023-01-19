#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void wacky_sharp_lexical_error() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("# class T { int i; }");
            // Exercise
            Check.ThatCode(() => GRun.Read(inputStream))
                 .Throws<GRunLexerException>()
                 .WhichMember(e => e.ErrorDetails)
                 .ContainsExactly("line 1:0 token recognition error at: '#'");
        }

        [Fact]
        public void missing_class_name_error() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class { int i; }");
            // Exercise
            Check.ThatCode(() => GRun.Read(inputStream))
                 .Throws<ParseCanceledException>(;
        }

    }

}