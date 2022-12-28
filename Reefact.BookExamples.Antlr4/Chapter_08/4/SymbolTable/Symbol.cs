#region Usings declarations

using System.Diagnostics;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

[DebuggerDisplay("{ToString()}")]
public class Symbol : IEquatable<Symbol> {

    public static bool operator ==(Symbol? left, Symbol? right) {
        return Equals(left, right);
    }

    public static bool operator !=(Symbol? left, Symbol? right) {
        return !Equals(left, right);
    }

    #region Constructors declarations

    public Symbol(string name, SymbolType type, IScope scope) {
        if (name is null) { throw new ArgumentNullException(nameof(name)); }

        Name  = name;
        Type  = type;
        Scope = scope;
    }

    #endregion

    public SymbolType Type  { get; }
    public IScope     Scope { get; }
    public string     Name  { get; }

    public override string ToString() {
        if (Type == SymbolType.Invalid) { return Name; }

        return '<' + Name + ":" + SymbolTypeConverter.Convert(Type) + '>';
    }

    /// <inheritdoc />
    public bool Equals(Symbol? other) {
        if (ReferenceEquals(null, other)) { return false; }
        if (ReferenceEquals(this, other)) { return true; }

        return Type == other.Type && Scope.Equals(other.Scope) && Name == other.Name;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) { return false; }
        if (ReferenceEquals(this, obj)) { return true; }
        if (obj.GetType() != GetType()) { return false; }

        return Equals((Symbol)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode() {
        return HashCode.Combine((int)Type, Scope, Name);
    }

}