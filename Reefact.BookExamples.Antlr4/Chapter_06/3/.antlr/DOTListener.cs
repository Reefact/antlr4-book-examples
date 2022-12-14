//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from DOT.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DOTParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IDOTListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.graph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGraph([NotNull] DOTParser.GraphContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.graph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGraph([NotNull] DOTParser.GraphContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.stmt_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmt_list([NotNull] DOTParser.Stmt_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.stmt_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmt_list([NotNull] DOTParser.Stmt_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmt([NotNull] DOTParser.StmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmt([NotNull] DOTParser.StmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.attr_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttr_stmt([NotNull] DOTParser.Attr_stmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.attr_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttr_stmt([NotNull] DOTParser.Attr_stmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.attr_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttr_list([NotNull] DOTParser.Attr_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.attr_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttr_list([NotNull] DOTParser.Attr_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.a_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterA_list([NotNull] DOTParser.A_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.a_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitA_list([NotNull] DOTParser.A_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.edge_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEdge_stmt([NotNull] DOTParser.Edge_stmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.edge_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEdge_stmt([NotNull] DOTParser.Edge_stmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.edgeRHS"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEdgeRHS([NotNull] DOTParser.EdgeRHSContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.edgeRHS"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEdgeRHS([NotNull] DOTParser.EdgeRHSContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.edgeop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEdgeop([NotNull] DOTParser.EdgeopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.edgeop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEdgeop([NotNull] DOTParser.EdgeopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.node_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNode_stmt([NotNull] DOTParser.Node_stmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.node_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNode_stmt([NotNull] DOTParser.Node_stmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.node_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNode_id([NotNull] DOTParser.Node_idContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.node_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNode_id([NotNull] DOTParser.Node_idContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.port"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPort([NotNull] DOTParser.PortContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.port"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPort([NotNull] DOTParser.PortContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.subgraph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubgraph([NotNull] DOTParser.SubgraphContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.subgraph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubgraph([NotNull] DOTParser.SubgraphContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DOTParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterId([NotNull] DOTParser.IdContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DOTParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitId([NotNull] DOTParser.IdContext context);
}
