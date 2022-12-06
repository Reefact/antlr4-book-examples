#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._2 {

    public sealed class InsertSerialIdListener : JavaBaseListener {

        #region Fields declarations

        private readonly TokenStreamRewriter _rewriter;

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public InsertSerialIdListener(ITokenStream tokenStream) {
            if (tokenStream is null) { throw new ArgumentNullException(nameof(tokenStream)); }

            _rewriter = new TokenStreamRewriter(tokenStream);
        }

        #endregion

        /// <inheritdoc />
        public override void EnterClassBody(JavaParser.ClassBodyContext context) {
            var field = "\r\n\tpublic static final long serialVersionUID = 1L;";
            _rewriter.InsertAfter(context.Start, field);
        }

        public string Rewrite() {
            return _rewriter.GetText();
        }

    }

}