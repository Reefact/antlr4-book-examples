#region Usings declarations

using System.Reflection;
using System.Text;

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4 {

    internal static class ResourcesHelper {

        private const string ResourcesFullNamePrefix = "Reefact.BookExamples.Antlr4.Chapter_";
        private const string ResourcesFolderName     = ".resources";

        #region Statics members declarations

        public static string Read(string resourceName, params int[] chapter) {
            if (resourceName is null) { throw new ArgumentNullException(nameof(resourceName)); }
            if (chapter is null) { throw new ArgumentNullException(nameof(chapter)); }

            string        resourceFullName = BuildResourceFullName(chapter, resourceName);
            var           assembly         = Assembly.GetExecutingAssembly();
            using Stream? stream           = assembly.GetManifestResourceStream(resourceFullName);
            if (stream == null) { throw new FileNotFoundException($"Resource '{resourceFullName}' does not exist or not declared as embedded resource."); }

            using StreamReader reader = new(stream);
            string             result = reader.ReadToEnd();

            return result;
        }

        public static string Read(string resourceRelativeName) {
            if (resourceRelativeName is null) { throw new ArgumentNullException(nameof(resourceRelativeName)); }

            var assembly         = Assembly.GetExecutingAssembly();
            var resourceFullName = $"Reefact.BookExamples.Antlr4.Resources.{resourceRelativeName}";

            using Stream? stream = assembly.GetManifestResourceStream(resourceFullName);
            if (stream == null) { throw new FileNotFoundException($"Resource '{resourceFullName}' does not exist or not declared as embedded resource."); }

            using StreamReader reader = new(stream);
            string             result = reader.ReadToEnd();

            return result;
        }

        private static string BuildResourceFullName(int[] chapterParts, string resourceName) {
            StringBuilder builder         = new(ResourcesFullNamePrefix);
            string        chapterLevelOne = chapterParts[0].ToString().PadLeft(2, '0');
            builder.Append(chapterLevelOne);
            for (var i = 1; i < chapterParts.Length; i++) {
                builder.Append("._").Append(chapterParts[i]);
            }
            builder.Append(".").Append(ResourcesFolderName)
                   .Append(".").Append(resourceName);

            return builder.ToString();
        }

        #endregion

    }

}