//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from LExpr.g4 by ANTLR 4.11.1

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
/// <see cref="LExprParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface ILExprListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="LExprParser.s"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterS([NotNull] LExprParser.SContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LExprParser.s"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitS([NotNull] LExprParser.SContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Add</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdd([NotNull] LExprParser.AddContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Add</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdd([NotNull] LExprParser.AddContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Mult</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMult([NotNull] LExprParser.MultContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Mult</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMult([NotNull] LExprParser.MultContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt([NotNull] LExprParser.IntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="LExprParser.e"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt([NotNull] LExprParser.IntContext context);
}
