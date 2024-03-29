﻿#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._1 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun {

        #region Statics members declarations

        public static GRun Read(AntlrInputStream inputStream) {
            XmlLexer lexer = new(inputStream);

            return new GRun(lexer.GetAllTokens().Select(t => t.ToString())!);
        }

        #endregion

        #region Fields declarations

        private readonly IEnumerable<string> _tokens;

        #endregion

        #region Constructors declarations

        private GRun(IEnumerable<string> tokens) {
            _tokens = tokens;
        }

        #endregion

        public string[] GetTokens() {
            return _tokens.ToArray();
        }

    }

}