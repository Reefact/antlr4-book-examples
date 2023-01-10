#region Usings declarations

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._4 {

    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadVec(AntlrInputStream inputStream) {
            VecLexer          lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            VecParser         parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.vec4);
        }

        public static GRun ReadVecMsg(AntlrInputStream inputStream) {
            VecMsgLexer       lexer  = new(inputStream);
            CommonTokenStream tokens = new(lexer);
            VecMsgParser      parser = new(tokens);

            return new GRun(lexer, tokens, parser, parser.vec4);
        }

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public GRun(Lexer lexer, CommonTokenStream tokenStream, Parser parser, Func<IParseTree> parse, Action<Parser>? options = null) : base(lexer, tokenStream, parser, parse, options) { }

        #endregion

    }

}