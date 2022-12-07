#region Usings declarations

using Antlr4.Runtime;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._3 {

    public class Examples {

        [Fact]
        public void extract_interface() {
            // Setup
            string           inputDemoClassCode        = ResourcesHelper.Read("Demo.java", 4, 3);
            string           expectedDemoInterfaceCode = ResourcesHelper.Read("IDemo.java", 4, 3);
            AntlrInputStream inputStream               = AntlrInputStreamReader.Read(inputDemoClassCode);
            GRun             grun                      = GRun.Read(inputStream);
            // Exercise
            string extractedDemoInterfaceCode = grun.ExtractInterface();
            // Verify
            Check.That(extractedDemoInterfaceCode).IsEqualTo(expectedDemoInterfaceCode);
        }

    }

}