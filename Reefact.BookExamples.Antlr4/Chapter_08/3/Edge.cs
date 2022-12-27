#region Usings declarations

using System.Diagnostics;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3;

[DebuggerDisplay("{ToString()}")]
public sealed class Edge : IEquatable<Edge> {

    public static bool operator ==(Edge? left, Edge? right) {
        return Equals(left, right);
    }

    public static bool operator !=(Edge? left, Edge? right) {
        return !Equals(left, right);
    }

    #region Constructors declarations

    public Edge(NodeName source, NodeName target) {
        if (source is null) { throw new ArgumentNullException(nameof(source)); }
        if (target is null) { throw new ArgumentNullException(nameof(target)); }

        Source = source;
        Target = target;
    }

    #endregion

    public NodeName Source { get; }
    public NodeName Target { get; }

    /// <inheritdoc />
    public bool Equals(Edge? other) {
        if (ReferenceEquals(null, other)) { return false; }
        if (ReferenceEquals(this, other)) { return true; }

        return Source == other.Source && Target == other.Target;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) {
        return ReferenceEquals(this, obj) || (obj is Edge other && Equals(other));
    }

    /// <inheritdoc />
    public override int GetHashCode() {
        return HashCode.Combine(Source, Target);
    }

    /// <inheritdoc />
    public override string ToString() {
        return $"{Source} -> {Target}";
    }

}