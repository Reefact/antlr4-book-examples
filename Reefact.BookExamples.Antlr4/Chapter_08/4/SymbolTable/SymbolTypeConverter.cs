namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable;

public static class SymbolTypeConverter {

    #region Statics members declarations

    public static SymbolType Convert(int tokenType) {
        return tokenType switch {
            Cymbol_8_4Parser.K_VOID  => SymbolType.Void,
            Cymbol_8_4Parser.K_INT   => SymbolType.Integer,
            Cymbol_8_4Parser.K_FLOAT => SymbolType.Float,
            _                        => SymbolType.Invalid
        };
    }

    public static string Convert(SymbolType symbolType) {
        return symbolType switch {
            SymbolType.Void    => "void",
            SymbolType.Integer => "int",
            SymbolType.Float   => "float",
            _                  => throw new ArgumentOutOfRangeException(nameof(symbolType), symbolType, null)
        };
    }

    #endregion

}