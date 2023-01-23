//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Call.g4 by ANTLR 4.11.1

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
public partial class CallParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, ID=4, INT=5;
	public const int
		RULE_stat = 0, RULE_fcall = 1, RULE_expr = 2;
	public static readonly string[] ruleNames = {
		"stat", "fcall", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, "';'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "ID", "INT"
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

	public override string GrammarFileName { get { return "Call.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CallParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CallParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CallParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class StatContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public FcallContext fcall() {
			return GetRuleContext<FcallContext>(0);
		}
		public StatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_stat; } }
	}

	[RuleVersion(0)]
	public StatContext stat() {
		StatContext _localctx = new StatContext(Context, State);
		EnterRule(_localctx, 0, RULE_stat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 6;
			fcall();
			State = 7;
			Match(T__0);
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

	public partial class FcallContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(CallParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public FcallContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_fcall; } }
	}

	[RuleVersion(0)]
	public FcallContext fcall() {
		FcallContext _localctx = new FcallContext(Context, State);
		EnterRule(_localctx, 2, RULE_fcall);
		try {
			State = 26;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 9;
				Match(ID);
				State = 10;
				Match(T__1);
				State = 11;
				expr();
				State = 12;
				Match(T__2);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 14;
				Match(ID);
				State = 15;
				Match(T__1);
				State = 16;
				expr();
				State = 17;
				Match(T__2);
				State = 18;
				Match(T__2);
				 NotifyErrorListeners("Too many parentheses."); 
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 21;
				Match(ID);
				State = 22;
				Match(T__1);
				State = 23;
				expr();
				 NotifyErrorListeners ("Missing closing ')'."); 
				}
				break;
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

	public partial class ExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(CallParser.INT, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(Context, State);
		EnterRule(_localctx, 4, RULE_expr);
		try {
			State = 33;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 28;
				Match(T__1);
				State = 29;
				expr();
				State = 30;
				Match(T__2);
				}
				break;
			case INT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 32;
				Match(INT);
				}
				break;
			default:
				throw new NoViableAltException(this);
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
		4,1,5,36,2,0,7,0,2,1,7,1,2,2,7,2,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,27,8,1,1,2,1,2,1,2,1,2,1,
		2,3,2,34,8,2,1,2,0,0,3,0,2,4,0,0,35,0,6,1,0,0,0,2,26,1,0,0,0,4,33,1,0,
		0,0,6,7,3,2,1,0,7,8,5,1,0,0,8,1,1,0,0,0,9,10,5,4,0,0,10,11,5,2,0,0,11,
		12,3,4,2,0,12,13,5,3,0,0,13,27,1,0,0,0,14,15,5,4,0,0,15,16,5,2,0,0,16,
		17,3,4,2,0,17,18,5,3,0,0,18,19,5,3,0,0,19,20,6,1,-1,0,20,27,1,0,0,0,21,
		22,5,4,0,0,22,23,5,2,0,0,23,24,3,4,2,0,24,25,6,1,-1,0,25,27,1,0,0,0,26,
		9,1,0,0,0,26,14,1,0,0,0,26,21,1,0,0,0,27,3,1,0,0,0,28,29,5,2,0,0,29,30,
		3,4,2,0,30,31,5,3,0,0,31,34,1,0,0,0,32,34,5,5,0,0,33,28,1,0,0,0,33,32,
		1,0,0,0,34,5,1,0,0,0,2,26,33
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}