﻿#region Usings declarations

using Antlr4.Runtime;

using ApprovalTests;
using ApprovalTests.Reporters;

using Reefact.BookExamples.Antlr4.Chapter_09._1;

using Xunit;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._3._3 {

    [UseReporter(typeof(CustomReporter))]
    public class Examples {

        [Fact]
        public void single_token_deletion_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T {{ int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string mermaidStyleTree = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(mermaidStyleTree);
        }

        [Fact]
        public void single_token_deletion_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("class T {{ int i; }");
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void messed_up_input_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("messed_up.simple", 9, 3, 3);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void messed_up_input_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("messed_up.simple", 9, 3, 3);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void resynchronisation_set_of_the_current_output() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("resynchronisation_set_of_the_current.simple", 9, 3, 3);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.GetOutput();
            // Verify
            Approvals.Verify(output);
        }

        [Fact]
        public void resynchronisation_set_of_the_current_mermaid_style_tree() {
            // Setup
            AntlrInputStream inputStream = AntlrInputStreamReader.Read("resynchronisation_set_of_the_current.simple", 9, 3, 3);
            GRun             grun        = GRun.Read(inputStream);
            // Exercise
            string output = grun.ToMermaidStyleTree();
            // Verify
            Approvals.Verify(output);
        }

    }

}