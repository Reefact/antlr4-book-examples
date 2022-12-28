#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4 {

    public class Examples {

        [Fact]
        public void check_vars_symbols() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("vars.cymbol", 8, 4);
            object[] expectedErrorMessages = {
                "line 3:1 no such variable: i",
                "line 4:1 g is not a variable",
                "line 13:1 no such function: z",
                "line 14:1 y is not a function",
                "line 15:5 f is not a variable"
            };
            GRun grun = GRun.Read(inputStream);
            // Exercise
            ProcessResult result = grun.CheckSymbols();
            // Verify
            Check.That(result.HasError).IsTrue();
            Check.That(result.ErrorMessages).IsEqualTo(expectedErrorMessages);
        }

        [Fact]
        public void check_vars_scopes() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("vars.cymbol", 8, 4);
            object[] expectedResult = {
                "locals:[]",
                "function<f:int>:[<x:int>, <y:float>]",
                "locals:[x, y]",
                "function<g:void>:[]",
                "globals:[f, g]"
            };
            GRun grun = GRun.Read(inputStream);
            // Exercise
            IEnumerable<string> result = grun.GetScopes();
            // Verify
            Check.That(result).IsEqualTo(expectedResult);
        }

        [Fact]
        public void check_vars2_symbols() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("vars2.cymbol", 8, 4);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            ProcessResult result = grun.CheckSymbols();
            // Verify
            Check.That(result.HasNoError).IsTrue();
            Check.That(result.ErrorMessages).IsEmpty();
        }

        [Fact]
        public void check_vars2_scopes() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("vars2.cymbol", 8, 4);
            GRun             grun        = GRun.Read(inputStream);
            object[] expectedResult = {
                "globals:[x, y, a, b]",
                "function<a:void>:[]",
                "locals:[x]",
                "locals:[y]",
                "function<b:void>:[<z:int>]",
                "locals:[]"
            };
            // Exercise
            IEnumerable<string> result = grun.GetScopes();
            // Verify
            // Verify
            Check.That(result).IsEquivalentTo(expectedResult);
        }

    }

}