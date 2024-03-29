﻿#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            Cymbol_8_4Lexer   lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            Cymbol_8_4Parser  parser = new(tokens);
            parser.BuildParseTree = true;

            return new GRun(lexer, tokens, parser, parser.file);
        }

        #endregion

        #region Constructors declarations

        private GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse) : base(lexer, tokenStream, parser, parse) { }

        #endregion

        public ProcessResult CheckSymbols() {
            ParseTreeWalker walker = new();
            // first phase
            DefPhase def = new();
            walker.Walk(def, Tree);
            // second phase
            RefPhase? @ref = new(def.GlobalScope, def.Scopes);
            walker.Walk(@ref, Tree);

            return new ProcessResult(@ref.GetErrors());
        }

        public IEnumerable<string> GetScopes() {
            ParseTreeWalker walker = new();
            DefPhase        def    = new();
            walker.Walk(def, Tree);

            return def.GetScopes().Select(s => s.ToString() ?? string.Empty);
        }

    }

}