#region Usings declarations

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_03;

public static class UnicodeStringConverter {

    #region Statics members declarations

    public static string ToUnicodeString(this GRun grun) {
        if (grun is null) { throw new ArgumentNullException(nameof(grun)); }

        // create a generic parse tree walker that can trigger callbacks
        var walker = new ParseTreeWalker();
        // walk the tree created during the parse, trigger callbacks
        ShortToUnicodeString shortToUnicodeString = new();
        walker.Walk(shortToUnicodeString, grun.Tree);

        return shortToUnicodeString.ToString();
    }

    #endregion

}