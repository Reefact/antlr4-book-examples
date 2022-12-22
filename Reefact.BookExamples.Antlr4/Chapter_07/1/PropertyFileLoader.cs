#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_07._1 {

    public sealed class PropertyFileLoader : PropertyFileParser {

        #region Fields declarations

        private readonly Dictionary<string, string> _properties = new();

        #endregion

        #region Constructors declarations

        /// <inheritdoc />
        public PropertyFileLoader(ITokenStream input) : base(input) { }

        /// <inheritdoc />
        public PropertyFileLoader(ITokenStream input, TextWriter output, TextWriter errorOutput) : base(input, output, errorOutput) { }

        #endregion

        /// <inheritdoc />
        public override string ToString() {
            return _properties.Select(p => $"{p.Key}={p.Value}")
                              .Aggregate((current, next) => $"{current}{Environment.NewLine}{next}");
        }

        protected override void DefineProperty(IToken name, IToken value) {
            _properties.Add(name.Text, value.Text);
        }

    }

}