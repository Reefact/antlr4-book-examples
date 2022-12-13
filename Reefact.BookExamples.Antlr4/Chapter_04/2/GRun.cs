﻿#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_04._2 {

    [DebuggerDisplay("{ToString()}")]
    public sealed class GRun : GRunBase {

        #region Statics members declarations

        public static GRun ReadResource(string resourceName, params int[] chapter) {
            string            inputString = ResourcesHelper.Read(resourceName, chapter);
            AntlrInputStream  inputStream = AntlrInputStreamReader.Read(inputString);
            LabeledExprLexer  lexer       = new(inputStream);
            CommonTokenStream tokens      = new(lexer);
            var               parser      = new LabeledExprParser(tokens);
            IParseTree        tree        = parser.prog();

            return new GRun(tree, parser, tokens);
        }

        #endregion

        #region Constructors declarations

        private GRun(IParseTree tree, LabeledExprParser parser, CommonTokenStream commonTokenStream) : base(tree, parser, commonTokenStream) { }

        #endregion

        public int[] Eval() {
            EvalVisitor visitor = new();
            visitor.Visit(Tree);

            return visitor.GetResults()
                          .ToArray();
        }

    }

}