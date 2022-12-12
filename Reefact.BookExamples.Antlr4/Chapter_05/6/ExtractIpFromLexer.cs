#region Usings declarations

using System.Net;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6 {

    public class ExtractIpFromLexer : IP_LexerBaseListener {

        #region Fields declarations

        private readonly HashSet<IPAddress> _ipAddresses = new();

        #endregion

        /// <inheritdoc />
        public override void EnterRow(IP_LexerParser.RowContext context) {
            string    ipAsString = context.IP().GetText();      // IP is not split 
            IPAddress ip         = IPAddress.Parse(ipAsString); // so IP must be parsed on the application side
            _ipAddresses.Add(ip);
        }

        public IEnumerable<IPAddress> GetAddresses() {
            return _ipAddresses;
        }

    }

}