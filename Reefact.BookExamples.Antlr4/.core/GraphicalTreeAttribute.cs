// ReSharper disable once CheckNamespace

namespace Reefact.BookExamples.Antlr4 {

    /// <summary>Indicates that a SVG visualization of the parse tree is available in local resources.</summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class GraphicalTreeAttribute : Attribute {

        #region Constructors declarations

        public GraphicalTreeAttribute(string resourceName) {
            if (string.IsNullOrWhiteSpace(resourceName)) { throw new ArgumentException("Value cannot be null or whitespace.", nameof(resourceName)); }

            ResourceName = resourceName;
        }

        #endregion

        public string ResourceName { get; }

    }

}