﻿#region Usings declarations

using ApprovalTests.Reporters;

using NFluent;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._5._2 {

    [UseReporter(typeof(VisualStudioReporter))]
    public class Examples {

        [Fact]
        public void rewrite_input_stream() {
            // Setup
            GRun   grun                  = GRun.ReadResource("Demo.java", 4, 3);
            string expectedRewritedClass = ResourcesHelper.Read("Demo_rewrited.java", 4, 5, 2);
            // Exercise
            string rewritedClass = grun.Rewrite();
            // Verify
            Check.That(rewritedClass).IsEqualTo(expectedRewritedClass);
        }

    }

}