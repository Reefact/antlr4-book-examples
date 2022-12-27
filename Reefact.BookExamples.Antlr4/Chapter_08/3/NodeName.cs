#region Usings declarations

using System.Diagnostics;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class NodeName : IEquatable<NodeName> {

        public static bool operator ==(NodeName? left, NodeName? right) {
            return Equals(left, right);
        }

        public static bool operator !=(NodeName? left, NodeName? right) {
            return !Equals(left, right);
        }

        #region Fields declarations

        private readonly string _value;

        #endregion

        #region Constructors declarations

        public NodeName(string value) {
            if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Value cannot be null or whitespace.", nameof(value)); }

            _value = value;
        }

        #endregion

        /// <inheritdoc />
        public bool Equals(NodeName? other) {
            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return _value == other._value;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) {
            return ReferenceEquals(this, obj) || (obj is NodeName other && Equals(other));
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return _value.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString() {
            return _value;
        }

    }

}