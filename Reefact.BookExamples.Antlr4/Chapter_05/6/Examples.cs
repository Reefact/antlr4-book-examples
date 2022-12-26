#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6 {

    public class Examples {

        [Fact]
        public void extract_IP_using_lexer() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("service.log", 5, 6);
            GRun             grun        = GRun.Read(ReadMode.Lexer, inputStream);
            // Exercise
            IReadOnlySet<string> ipAddresses = grun.Collect();
            Check.That(ipAddresses).CountIs(2);
            Check.That(ipAddresses).Contains("127.0.0.1");
            Check.That(ipAddresses).Contains("192.168.209.85");
        }

        [Fact]
        public void extract_IP_using_parser() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("service.log", 5, 6);
            GRun             grun        = GRun.Read(ReadMode.Parser, inputStream);
            // Exercise
            IReadOnlySet<string> ipAddresses = grun.Collect();
            Check.That(ipAddresses).CountIs(2);
            Check.That(ipAddresses).Contains("127.0.0.1");
            Check.That(ipAddresses).Contains("192.168.209.85");
        }

    }

}