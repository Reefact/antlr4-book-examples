//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Pred.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class PredParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, ID=3, INT=4;
	public const int
		RULE_assign = 0;
	public static readonly string[] ruleNames = {
		"assign"
	};

	private static readonly string[] _LiteralNames = {
		null, "'='", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "ID", "INT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Pred.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static PredParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public PredParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public PredParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class AssignContext : ParserRuleContext {
		public IToken v;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(PredParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(PredParser.INT, 0); }
		public AssignContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assign; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPredListener typedListener = listener as IPredListener;
			if (typedListener != null) typedListener.EnterAssign(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPredListener typedListener = listener as IPredListener;
			if (typedListener != null) typedListener.ExitAssign(this);
		}
	}

	[RuleVersion(0)]
	public AssignContext assign() {
		AssignContext _localctx = new AssignContext(Context, State);
		EnterRule(_localctx, 0, RULE_assign);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 2;
			Match(ID);
			State = 3;
			Match(T__0);
			State = 4;
			_localctx.v = Match(INT);
			 if ((_localctx.v!=null?int.Parse(_localctx.v.Text):0)==0) NotifyErrorListeners("values must be > 0"); 
			State = 6;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,4,9,2,0,7,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,7,0,2,1,0,0,0,
		2,3,5,3,0,0,3,4,5,1,0,0,4,5,5,4,0,0,5,6,6,0,-1,0,6,7,5,2,0,0,7,1,1,0,0,
		0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
