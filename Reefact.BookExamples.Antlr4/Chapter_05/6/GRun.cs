#region Usings declarations

using System.Collections.Immutable;
using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(ReadMode readMode, AntlrInputStream inputStream) {
            return readMode switch {
                ReadMode.Lexer  => ReadLexer(inputStream),
                ReadMode.Parser => ReadParser(inputStream),
                _               => throw new ArgumentOutOfRangeException(nameof(readMode), readMode, null)
            };
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

            return new GRun(ipAddresses, tree, parser, tokens);
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

            return new GRun(ipAddresses, tree, parser, tokens);
        }

        #endregion

        #region Fields declarations

        private readonly IReadOnlySet<string> _ipAddresses;

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private GRun(IReadOnlySet<string> ipAddresses, IParseTree tree, Parser parser, CommonTokenStream tokenStream) : base(tree, parser, tokenStream) {
            _ipAddresses = ipAddresses;
        }

        #endregion

        public IReadOnlySet<string> Collect() {
            return _ipAddresses;
        }

    }

}