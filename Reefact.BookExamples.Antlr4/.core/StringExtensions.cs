#region Usings declarations

using System.Diagnostics.CodeAnalysis;

#endregion

namespace Reefact.BookExamples.Antlr4.core {

    internal static class StringExtensions {

        #region Statics members declarations

        [return: NotNullIfNotNull("input")]
        public static string? RemoveTrailing(this string? input, string? s) {
            if (input == null) { return null; }
            if (string.IsNullOrEmpty(s)) { return input; }

            int lastNewLineIndex = input.LastIndexOf(s, StringComparison.Ordinal);
            int inputLength      = input.Length - 2;
            if (lastNewLineIndex != inputLength) { return input; }

            return input[..inputLength];
        }

        #endregion

    }

}