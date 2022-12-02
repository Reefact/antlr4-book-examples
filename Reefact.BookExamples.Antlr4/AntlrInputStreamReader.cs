#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4;

public static class AntlrInputStreamReader {

    #region Statics members declarations

    public static AntlrInputStream Read(string @string) {
        if (@string is null) { throw new ArgumentNullException(nameof(@string)); }

        using TextReader reader      = new StringReader(@string);
        AntlrInputStream inputStream = new(reader);

        return inputStream;
    }

    public static AntlrInputStream Read(byte[] bytes) {
        if (bytes is null) { throw new ArgumentNullException(nameof(bytes)); }

        using MemoryStream memoryStream = new(bytes);
        AntlrInputStream   inputStream  = new(memoryStream);

        return inputStream;
    }

    #endregion

}