#region Usings declarations

using System.Diagnostics;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6;

// A custom IP address implementation to see a possible use case.
[DebuggerDisplay("{ToString()}")]
public sealed class MyCustomIpAddress : IEquatable<MyCustomIpAddress> {

    public static bool operator ==(MyCustomIpAddress? left, MyCustomIpAddress? right) {
        return Equals(left, right);
    }

    public static bool operator !=(MyCustomIpAddress? left, MyCustomIpAddress? right) {
        return !Equals(left, right);
    }

    #region Fields declarations

    private readonly int _a;
    private readonly int _b;
    private readonly int _c;
    private readonly int _d;

    #endregion

    #region Constructors declarations

    public MyCustomIpAddress(int a, int b, int c, int d) {
        _a = a;
        _b = b;
        _c = c;
        _d = d;
    }

    #endregion

    /// <inheritdoc />
    public override string ToString() {
        return $"{_a}.{_b}.{_c}.{_d}";
    }

    /// <inheritdoc />
    public bool Equals(MyCustomIpAddress? other) {
        if (ReferenceEquals(null, other)) { return false; }
        if (ReferenceEquals(this, other)) { return true; }

        return _a == other._a && _b == other._b && _c == other._c && _d == other._d;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) {
        return ReferenceEquals(this, obj) || (obj is MyCustomIpAddress other && Equals(other));
    }

    /// <inheritdoc />
    public override int GetHashCode() {
        return HashCode.Combine(_a, _b, _c, _d);
    }

}