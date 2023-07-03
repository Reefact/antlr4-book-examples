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
            IP_ParserLexer    lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            IP_ParserParser?  parser = new(tokens);

            return new GRun(ReadMode.Parser, lexer, tokens, parser, parser.file);
        }

        private static GRun ReadLexer(AntlrInputStream inputStream) {
            IP_LexerLexer     lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            IP_LexerParser?   parser = new(tokens);

            return new GRun(ReadMode.Lexer, lexer, tokens, parser, parser.file);
        }

        #endregion

        #region Fields declarations

        private readonly ReadMode _readMode;

        #endregion

        #region Constructors declarations

        private GRun(ReadMode readMode, Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) {
            _readMode = readMode;
        }

        #endregion

        public IReadOnlySet<string> Collect() {
            return _readMode switch {
                ReadMode.Lexer  => ExtractIpFromLexer(),
                ReadMode.Parser => ExtractIpFromParser(),
                _               => throw new ArgumentOutOfRangeException()
            };
        }

        private IReadOnlySet<string> ExtractIpFromParser() {
            ExtractIpFromParser extractor = new();
            extractor.Visit(Tree);
            IReadOnlySet<string> ipAddresses = extractor.GetAddresses()
                                                        .Select(ip => ip.ToString())
                                                        .ToImmutableHashSet();

            return ipAddresses;
        }

        private IReadOnlySet<string> ExtractIpFromLexer() {
            ParseTreeWalker    walker    = new();
            ExtractIpFromLexer extractor = new();
            walker.Walk(extractor, Tree);
            IReadOnlySet<string> ipAddresses = extractor.GetAddresses()
                                                        .Select(ip => ip.ToString())
                                                        .ToImmutableHashSet();

            return ipAddresses;
        }

    }

}