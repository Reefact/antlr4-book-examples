#region Usings declarations

using System.Reflection;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests {

    internal static class ResourcesHelper {

        #region Statics members declarations

        public static string Read(string resourceRelativeName) {
            if (resourceRelativeName is null) { throw new ArgumentNullException(nameof(resourceRelativeName)); }

            var assembly         = Assembly.GetExecutingAssembly();
            var resourceFullName = $"Reefact.BookExamples.Antlr4.UnitTests.Resources.{resourceRelativeName}";

            using Stream?      stream = assembly.GetManifestResourceStream(resourceFullName);
            using StreamReader reader = new(stream!);
            string             result = reader.ReadToEnd();

            return result;
        }

        #endregion

    }

}