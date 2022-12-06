#region Usings declarations

using Antlr4.Runtime;

using Reefact.BookExamples.Antlr4.Chapter_04._3;

#endregion

namespace Reefact.BookExamples.Antlr4.UnitTests.Chapter_04 {

    public class Examples_04_3 {

        [Fact]
        public void extract_interface() {
            // Setup
            string           inputDemoClassCode        = ResourcesHelper.Read("Chapter_04.Demo.java");
            string           expectedDemoInterfaceCode = ResourcesHelper.Read("Chapter_04.IDemo.java");
            AntlrInputStream inputStream               = AntlrInputStreamReader.Read(inputDemoClassCode);
            GRun             grun                      = GRun.Read(inputStream);
            // Exercise
            string extractedDemoInterfaceCode = grun.ExtractInterface();
            // Verify
            Check.That(extractedDemoInterfaceCode).IsEqualTo(expectedDemoInterfaceCode);
        }

    }

}