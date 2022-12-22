namespace Reefact.BookExamples.Antlr4.Chapter_07._2 {

    public sealed class PropertyFileLoader : PropertyFile_7_2BaseListener {

        #region Fields declarations

        private readonly Dictionary<string, string> _properties = new();

        #endregion

        /// <inheritdoc />
        public override void ExitProp(PropertyFile_7_2Parser.PropContext context) {
            string propertyName  = context.ID().GetText();
            string propertyValue = context.STRING().GetText();
            _properties.Add(propertyName, propertyValue);
        }

        /// <inheritdoc />
        public override string ToString() {
            return _properties.Select(p => $"{p.Key}={p.Value}")
                              .Aggregate((current, next) => $"{current}{Environment.NewLine}{next}");
        }

    }

}