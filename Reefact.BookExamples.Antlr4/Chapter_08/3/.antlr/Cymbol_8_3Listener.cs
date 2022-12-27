//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Cymbol_8_3.g4 by ANTLR 4.11.1

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
/// <see cref="Cymbol_8_3Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface ICymbol_8_3Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] Cymbol_8_3Parser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] Cymbol_8_3Parser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarDecl([NotNull] Cymbol_8_3Parser.VarDeclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarDecl([NotNull] Cymbol_8_3Parser.VarDeclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] Cymbol_8_3Parser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] Cymbol_8_3Parser.TypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.functionDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDecl([NotNull] Cymbol_8_3Parser.FunctionDeclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.functionDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDecl([NotNull] Cymbol_8_3Parser.FunctionDeclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.formalParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormalParameters([NotNull] Cymbol_8_3Parser.FormalParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.formalParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormalParameters([NotNull] Cymbol_8_3Parser.FormalParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.formalParameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormalParameter([NotNull] Cymbol_8_3Parser.FormalParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.formalParameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormalParameter([NotNull] Cymbol_8_3Parser.FormalParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] Cymbol_8_3Parser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] Cymbol_8_3Parser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStat([NotNull] Cymbol_8_3Parser.StatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStat([NotNull] Cymbol_8_3Parser.StatContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Call</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCall([NotNull] Cymbol_8_3Parser.CallContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Call</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCall([NotNull] Cymbol_8_3Parser.CallContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNot([NotNull] Cymbol_8_3Parser.NotContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNot([NotNull] Cymbol_8_3Parser.NotContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Mult</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMult([NotNull] Cymbol_8_3Parser.MultContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Mult</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMult([NotNull] Cymbol_8_3Parser.MultContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>AddSub</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddSub([NotNull] Cymbol_8_3Parser.AddSubContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>AddSub</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddSub([NotNull] Cymbol_8_3Parser.AddSubContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Equal</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEqual([NotNull] Cymbol_8_3Parser.EqualContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Equal</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEqual([NotNull] Cymbol_8_3Parser.EqualContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar([NotNull] Cymbol_8_3Parser.VarContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar([NotNull] Cymbol_8_3Parser.VarContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Parens</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParens([NotNull] Cymbol_8_3Parser.ParensContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Parens</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParens([NotNull] Cymbol_8_3Parser.ParensContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Index</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndex([NotNull] Cymbol_8_3Parser.IndexContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Index</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndex([NotNull] Cymbol_8_3Parser.IndexContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Negate</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNegate([NotNull] Cymbol_8_3Parser.NegateContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Negate</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNegate([NotNull] Cymbol_8_3Parser.NegateContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt([NotNull] Cymbol_8_3Parser.IntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="Cymbol_8_3Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt([NotNull] Cymbol_8_3Parser.IntContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Cymbol_8_3Parser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprList([NotNull] Cymbol_8_3Parser.ExprListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Cymbol_8_3Parser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprList([NotNull] Cymbol_8_3Parser.ExprListContext context);
}
