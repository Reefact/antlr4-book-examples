//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from R.g4 by ANTLR 4.11.1

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
/// <see cref="RParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IRListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] RParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] RParser.ProgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.expr_or_assign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr_or_assign([NotNull] RParser.Expr_or_assignContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.expr_or_assign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr_or_assign([NotNull] RParser.Expr_or_assignContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] RParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] RParser.ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.exprlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprlist([NotNull] RParser.ExprlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.exprlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprlist([NotNull] RParser.ExprlistContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.formlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormlist([NotNull] RParser.FormlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.formlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormlist([NotNull] RParser.FormlistContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.form"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForm([NotNull] RParser.FormContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.form"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForm([NotNull] RParser.FormContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.sublist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSublist([NotNull] RParser.SublistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.sublist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSublist([NotNull] RParser.SublistContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RParser.sub"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSub([NotNull] RParser.SubContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RParser.sub"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSub([NotNull] RParser.SubContext context);
}
