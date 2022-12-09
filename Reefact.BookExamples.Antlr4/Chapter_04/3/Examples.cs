#region Usings declarations

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._3 {

    public class Examples {

        [Fact]
        public void extract_interface_from_class() {
            // Setup
            GRun   grun                  = GRun.ReadResource("Demo.java", 4, 3);
            string expectedInterfaceCode = ResourcesHelper.Read("IDemo.java", 4, 3);
            // Exercise
            string extractedInterfaceCode = grun.ExtractInterface();
            // Verify
            Check.That(extractedInterfaceCode).IsEqualTo(expectedInterfaceCode);
        }

    }

}