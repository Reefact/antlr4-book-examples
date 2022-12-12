#region Usings declarations

using System.Collections.Immutable;
using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun {

        #region Statics members declarations

        public static GRun ReadResource(ReadMode readMode, string resourceName, params int[] chapter) {
            string           inputString = ResourcesHelper.Read(resourceName, chapter);
            AntlrInputStream inputStream = AntlrInputStreamReader.Read(inputString);
            switch (readMode) {
                case ReadMode.Lexer:  return ReadLexer(inputStream);
                case ReadMode.Parser: return ReadParser(inputStream);
                default:              throw new ArgumentOutOfRangeException(nameof(readMode), readMode, null);
            }
        }

        private static GRun ReadParser(AntlrInputStream inputStream) {
            IP_ParserLexer      lexer     = new(inputStream);
            CommonTokenStream   tokens    = new(lexer);
            var                 parser    = new IP_ParserParser(tokens);
            IParseTree          tree      = parser.file();
            ExtractIpFromParser extractor = new();
            extractor.Visit(tree);
            IReadOnlySet<string> ipAddresses = extractor.GetAddresses()
                                                        .Select(ip => ip.ToString())
                                                        .ToImmutableHashSet();

            return new GRun(ipAddresses);
        }

        private static GRun ReadLexer(AntlrInputStream inputStream) {
            IP_LexerLexer      lexer     = new(inputStream);
            CommonTokenStream  tokens    = new(lexer);
            var                parser    = new IP_LexerParser(tokens);
            IParseTree         tree      = parser.file();
            ParseTreeWalker    walker    = new();
            ExtractIpFromLexer extractor = new();
            walker.Walk(extractor, tree);
            IReadOnlySet<string> ipAddresses = extractor.GetAddresses()
                                                        .Select(ip => ip.ToString())
                                                        .ToImmutableHashSet();

            return new GRun(ipAddresses);
        }

        #endregion

        #region Fields declarations

        private readonly IReadOnlySet<string> _ipAddresses;

        #endregion

        #region Constructors declarations

        private GRun(IReadOnlySet<string> ipAddresses) {
            _ipAddresses = ipAddresses;
        }

        #endregion

        public IReadOnlySet<string> Collect() {
            return _ipAddresses;
        }

    }

}