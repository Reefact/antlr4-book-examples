//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from JSON.g4 by ANTLR 4.11.1

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
/// <see cref="JSONParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IJSONListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="JSONParser.json"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterJson([NotNull] JSONParser.JsonContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JSONParser.json"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitJson([NotNull] JSONParser.JsonContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JSONParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObject([NotNull] JSONParser.ObjectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JSONParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObject([NotNull] JSONParser.ObjectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JSONParser.pair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPair([NotNull] JSONParser.PairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JSONParser.pair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPair([NotNull] JSONParser.PairContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JSONParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray([NotNull] JSONParser.ArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JSONParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray([NotNull] JSONParser.ArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JSONParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] JSONParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JSONParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] JSONParser.ValueContext context);
}
