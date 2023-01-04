#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using Reefact.BookExamples.Antlr4.core;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class AmbiguousGRun : GRunBase {

        #region Statics members declarations

        public static AmbiguousGRun Read(AntlrInputStream inputStream, Action<Parser> options, params BaseErrorListener[] syntacticalErrorListeners) {
            AmbigLexer        lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            AmbigParser       parser = new(tokens);

            return new AmbiguousGRun(lexer, parser, parser.stat, tokens, options, syntacticalErrorListeners);
        }

        public static AmbiguousGRun Read(AntlrInputStream inputStream, params BaseErrorListener[] syntacticalErrorListeners) {
            AmbigLexer        lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            AmbigParser       parser = new(tokens);

            return new AmbiguousGRun(lexer, parser, parser.stat, tokens, null, syntacticalErrorListeners);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        private AmbiguousGRun(Lexer lexer, Parser parser, Func<IParseTree> parse, CommonTokenStream tokenStream, Action<Parser>? options, params BaseErrorListener[] syntacticalErrorListeners) : base(lexer, tokenStream, parser, parse, options, syntacticalErrorListeners) { }

        #endregion

        public string GetOutput() {
            StringBuilder builder = new();
            foreach (BaseErrorListener errorListener in SyntacticalErrorListeners) {
                if (errorListener is not IErrorListenerWithOutput errorListenerWithOutput) { continue; }

                builder.AppendLine(errorListenerWithOutput.GetOutput());
            }

            var output = builder.ToString();

            return output.RemoveTrailing(Environment.NewLine);
        }

    }

}