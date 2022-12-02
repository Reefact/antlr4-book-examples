#region Usings declarations

using System.Diagnostics;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4;

[DebuggerDisplay("{ToString()}")]
public abstract class GRunBase {

    #region Constructors declarations

    protected GRunBase(IParseTree tree, Parser parser) {
        if (tree is null) { throw new ArgumentNullException(nameof(tree)); }
        if (parser is null) { throw new ArgumentNullException(nameof(parser)); }

        Tree   = tree;
        Parser = parser;
    }

    #endregion

    protected IParseTree Tree   { get; }
    protected Parser     Parser { get; }

    public string ToLispStyleTree() {
        return Tree.ToStringTree(Parser);
    }

    /// <inheritdoc />
    public override string ToString() {
        return ToLispStyleTree();
    }

}