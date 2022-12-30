#region Usings declarations

using System.Text;

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._2 {

    public sealed class XmlEmitter : JSON_8_2BaseListener {

        #region Statics members declarations

        private static string StripQuotes(string rawString) {
            return rawString[1..^1];
        }

        #endregion

        #region Fields declarations

        private readonly ParseTreeProperty<string> _xml = new();

        private string _output = string.Empty;

        #endregion

        /// <inheritdoc />
        public override void ExitAtom(JSON_8_2Parser.AtomContext context) {
            string atom = context.GetText();

            _xml.Put(context, atom);
        }

        /// <inheritdoc />
        public override void ExitString(JSON_8_2Parser.StringContext context) {
            string @string = StripQuotes(context.GetText());

            _xml.Put(context, @string);
        }

        /// <inheritdoc />
        public override void ExitObjectValue(JSON_8_2Parser.ObjectValueContext context) {
            string objectValue = _xml.Get(context.@object());

            _xml.Put(context, objectValue);
        }

        /// <inheritdoc />
        public override void ExitArrayValue(JSON_8_2Parser.ArrayValueContext context) {
            string arrayValue = _xml.Get(context.array());

            _xml.Put(context, arrayValue);
        }

        /// <inheritdoc />
        public override void ExitPair(JSON_8_2Parser.PairContext context) {
            string                      tagName      = StripQuotes(context.STRING().GetText());
            JSON_8_2Parser.ValueContext valueContext = context.value();
            string                      value        = _xml.Get(valueContext);
            var                         tag          = $"<{tagName}>{value}</{tagName}>{Environment.NewLine}";

            _xml.Put(context, tag);
        }

        /// <inheritdoc />
        public override void ExitAnObject(JSON_8_2Parser.AnObjectContext context) {
            StringBuilder builder = new();
            builder.AppendLine();
            foreach (JSON_8_2Parser.PairContext pairContext in context.pair()) {
                string value = _xml.Get(pairContext);
                builder.Append(value);
            }
            var objectValue = builder.ToString();

            _xml.Put(context, objectValue);
        }

        /// <inheritdoc />
        public override void ExitEmptyObject(JSON_8_2Parser.EmptyObjectContext context) {
            _xml.Put(context, string.Empty);
        }

        /// <inheritdoc />
        public override void ExitArrayOfValues(JSON_8_2Parser.ArrayOfValuesContext context) {
            StringBuilder builder = new();
            builder.AppendLine();
            foreach (JSON_8_2Parser.ValueContext valueContext in context.value()) {
                builder.Append("<element>");
                builder.Append(_xml.Get(valueContext));
                builder.AppendLine("</element>");
            }
            var arrayValue = builder.ToString();

            _xml.Put(context, arrayValue);
        }

        /// <inheritdoc />
        public override void ExitEmptyArray(JSON_8_2Parser.EmptyArrayContext context) {
            _xml.Put(context, string.Empty);
        }

        /// <inheritdoc />
        public override void ExitJson(JSON_8_2Parser.JsonContext context) {
            IParseTree firstChild = context.GetChild(0);
            _output = _xml.Get(firstChild);

            _xml.Put(context, _output);
        }

        public string GetXml() {
            return _output;
        }

    }

}