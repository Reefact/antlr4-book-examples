#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6 {

    public class Examples {

        [Fact]
        public void extract_IP_using_lexer() {
            // Setup
            GRun grun = GRun.ReadResource(ReadMode.Lexer, "service.log", 5, 6);
            // Exercise
            IReadOnlySet<string> ipAddresses = grun.Collect();
            Check.That(ipAddresses).CountIs(2);
            Check.That(ipAddresses).Contains("127.0.0.1");
            Check.That(ipAddresses).Contains("192.168.209.85");
        }

        [Fact]
        public void extract_IP_using_parser() {
            // Setup
            GRun grun = GRun.ReadResource(ReadMode.Parser, "service.log", 5, 6);
            // Exercise
            IReadOnlySet<string> ipAddresses = grun.Collect();
            Check.That(ipAddresses).CountIs(2);
            Check.That(ipAddresses).Contains("127.0.0.1");
            Check.That(ipAddresses).Contains("192.168.209.85");
        }

    }

}