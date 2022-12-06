//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Data.g4 by ANTLR 4.11.1

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
/// <see cref="DataParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IDataListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DataParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] DataParser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DataParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] DataParser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DataParser.group"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroup([NotNull] DataParser.GroupContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DataParser.group"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroup([NotNull] DataParser.GroupContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DataParser.sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSequence([NotNull] DataParser.SequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DataParser.sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSequence([NotNull] DataParser.SequenceContext context);
}