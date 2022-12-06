#region Usings declarations

using System.Text;

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._3 {

    public sealed class ExtractInterfaceListener : JavaBaseListener {

        #region Fields declarations

        private readonly JavaParser _parser;

        private readonly StringBuilder _output = new();

        #endregion

        #region Constructors declarations

        public ExtractInterfaceListener(JavaParser parser) {
            if (parser is null) { throw new ArgumentNullException(nameof(parser)); }

            _parser = parser;
        }

        #endregion

        /// <inheritdoc />
        public override void EnterClassDeclaration(JavaParser.ClassDeclarationContext context) {
            _output.AppendLine($"interface I{context.Identifier()} {{");
        }

        /// <inheritdoc />
        public override void ExitClassDeclaration(JavaParser.ClassDeclarationContext context) {
            _output.Append("}");
        }

        /// <inheritdoc />
        public override void EnterMethodDeclaration(JavaParser.MethodDeclarationContext context) {
            ITokenStream           tokens      = _parser.TokenStream;
            var                    type        = "void";
            JavaParser.TypeContext typeContext = context.type();
            if (typeContext != null) {
                type = tokens.GetText(typeContext);
            }
            string args = tokens.GetText(context.formalParameters());
            _output.AppendLine($"\t{type} {context.Identifier()}{args};");
        }

        /// <inheritdoc />
        public override string ToString() {
            return _output.ToString();
        }

    }

}