#region Usings declarations

using System.Text;

using Antlr4.Runtime;

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4;

public static class AntlrInputStreamReader {

    #region Statics members declarations

    /// <summary>
    ///     Converts embedded resource named
    ///     <param name="resourceName" />
    ///     in specified
    ///     <param name="chapter">.</param>
    ///     to an <see cref="AntlrInputStream" />.
    /// </summary>
    /// <param name="resourceName">The name of the resource (must be embedded in a .resources folder).</param>
    /// <param name="chapter">The chapter number (eg. 1.2.3. => 1, 2, 3)</param>
    public static AntlrInputStream Read(string resourceName, params int[] chapter) {
        if (resourceName is null) { throw new ArgumentNullException(nameof(resourceName)); }
        if (chapter is null) { throw new ArgumentNullException(nameof(chapter)); }
        if (chapter.Length == 0) { throw new ArgumentException("Value cannot be an empty collection.", nameof(chapter)); }

        string           inputString = ResourcesHelper.Read(resourceName, chapter);
        AntlrInputStream inputStream = Read(inputString);

        return inputStream;
    }

    /// <summary>Converts a string to an <see cref="AntlrInputStream" />.</summary>
    public static AntlrInputStream Read(string @string) {
        if (@string is null) { throw new ArgumentNullException(nameof(@string)); }

        using TextReader reader      = new StringReader(@string);
        AntlrInputStream inputStream = new(reader);

        return inputStream;
    }

    /// <summary>Converts bytes to an <see cref="AntlrInputStream" />.</summary>
    public static AntlrInputStream Read(byte[] bytes) {
        if (bytes is null) { throw new ArgumentNullException(nameof(bytes)); }

        using MemoryStream memoryStream = new(bytes);
        AntlrInputStream   inputStream  = new(memoryStream);

        return inputStream;
    }

    /// <summary>Converts the content of a string build to an <see cref="AntlrInputStream" />.</summary>
    public static AntlrInputStream Read(StringBuilder stringBuilder) {
        var contentString = stringBuilder.ToString();

        return Read(contentString);
    }

    #endregion

}