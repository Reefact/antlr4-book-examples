#region Usings declarations

using Antlr4.Runtime;

using Reefact.Tools;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_10._1._3 {

    public sealed class Calc {

        #region Statics members declarations

        public static IEnumerable<int> Read(string s) {
            if (s is null) { throw new ArgumentNullException(nameof(s)); }

            using StringReader reader = new(s);
            string?            expr   = reader.ReadLine();
            var                line   = 1;
            ActionExprParser   parser = new(null);
            parser.BuildParseTree = false;
            while (expr != null) { // while we have more expressions
                // create new lexer and token stream for each line (expression)
                AntlrInputStream inputStream = new(expr + Environment.NewLine);
                ActionExprLexer  lexer       = new(inputStream);
                lexer.Line   = line; // notify lexer of input position
                lexer.Column = 0;
                CommonTokenStream tokens = new(lexer);
                parser.TokenStream = tokens; // notify parser of new token stream
                parser.stat();               // start the parser
                expr = reader.ReadLine();    //see if there's another line
                line++;
            }

            return parser.GetOutput();
        }

        #endregion

    }

}