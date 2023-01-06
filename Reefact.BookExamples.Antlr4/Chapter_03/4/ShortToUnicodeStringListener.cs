#region Usings declarations

using System.Text;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03._4;

/// <summary>
///     Convert short array inits like {1,2,3} to "\u0001\u0002\u0003"
/// </summary>
public sealed class ShortToUnicodeStringListener : ArrayInitBaseListener {

    private const string HexadecimalStringFormat = "x4";
    private const string UnicodePrefix           = "\\u";

    #region Statics members declarations

    private static string ConvertToUnicodeString(int value) {
        var valueAsHexString     = value.ToString(HexadecimalStringFormat);
        var valueAsUnicodeString = $"{UnicodePrefix}{valueAsHexString}";

        return valueAsUnicodeString;
    }

    #endregion

    #region Fields declarations

    private readonly StringBuilder _builder = new();

    #endregion

    /// <summary>Translate { to "</summary>
    public override void EnterInit(ArrayInitParser.InitContext context) {
        _builder.Append('"');
    }

    public override void ExitInit(ArrayInitParser.InitContext context) {
        _builder.Append('"');
    }

    /// <summary>Translate integers to 4-digit hexadecimal strings prefixed with \u.</summary>
    public override void EnterValue(ArrayInitParser.ValueContext context) {
        int    value                = int.Parse(context.INT().GetText());
        string valueAsUnicodeString = ConvertToUnicodeString(value);

        _builder.Append(valueAsUnicodeString);
    }

    public override string ToString() {
        return _builder.ToString();
    }

}