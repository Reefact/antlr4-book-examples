#region Usings declarations

using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._2 {

    public sealed class SimpleGRun : GRunBase {

        #region Statics members declarations

        public static SimpleGRun Read(AntlrInputStream inputStream, params BaseErrorListener[] syntacticalErrorListeners) {
            SimpleLexer       lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            SimpleParser      parser = new(tokens);

            return new SimpleGRun(lexer, tokens, parser, parser.prog, syntacticalErrorListeners);
        }

        #endregion

        #region Constructors declarations

        private SimpleGRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, params BaseErrorListener[] syntacticalErrorListeners) : base(lexer, tokenStream, parser, parse, null, syntacticalErrorListeners) { }

        #endregion

        protected override SimpleParser Parser => (SimpleParser)base.Parser;

        public string GetOutput() {
            StringBuilder builder = new();
            foreach (BaseErrorListener syntacticalErrorListener in SyntacticalErrorListeners) {
                if (syntacticalErrorListener is IErrorListenerWithOutput errorListenerWithOutput) {
                    builder.AppendLine(errorListenerWithOutput.GetOutput());
                }
            }
            builder.Append(Parser.GetOutput()
                                 .Aggregate((p, n) => $"{p}{Environment.NewLine}{n}"));

            return builder.ToString();
        }

    }

}