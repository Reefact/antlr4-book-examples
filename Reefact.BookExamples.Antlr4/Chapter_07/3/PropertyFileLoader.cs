namespace Reefact.BookExamples.Antlr4.Chapter_07._3 {

    public sealed class PropertyFileLoader : PropertyFile_7_3BaseVisitor<Void> {

        #region Fields declarations

        private readonly Dictionary<string, string> _properties = new();

        #endregion

        /// <inheritdoc />
        public override Void VisitProp(PropertyFile_7_3Parser.PropContext context) {
            string propertyName  = context.ID().GetText();
            string propertyValue = context.STRING().GetText();
            _properties.Add(propertyName, propertyValue);

            return Void.Value;
        }

        /// <inheritdoc />
        public override string ToString() {
            return _properties.Select(p => $"{p.Key}={p.Value}")
                              .Aggregate((current, next) => $"{current}{Environment.NewLine}{next}");
        }

    }

}