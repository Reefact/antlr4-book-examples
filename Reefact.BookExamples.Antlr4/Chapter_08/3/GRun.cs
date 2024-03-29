﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            Cymbol_8_3Lexer?  lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            Cymbol_8_3Parser? parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.file);
        }

        #endregion

        #region Constructors declarations

        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public string ToDot() {
            ParseTreeWalker    walker    = new();
            CallGraphGenerator generator = new();
            walker.Walk(generator, Tree);

            return generator.ToDot();
        }

    }

}