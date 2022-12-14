//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ArrayInit.g4 by ANTLR 4.11.1

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
public partial class ArrayInitParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, INT=4, WS=5;
	public const int
		RULE_init = 0, RULE_value = 1;
	public static readonly string[] ruleNames = {
		"init", "value"
	};

	private static readonly string[] _LiteralNames = {
		null, "'{'", "','", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "INT", "WS"
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

	public override string GrammarFileName { get { return "ArrayInit.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static ArrayInitParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public ArrayInitParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public ArrayInitParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class InitContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		public InitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_init; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IArrayInitListener typedListener = listener as IArrayInitListener;
			if (typedListener != null) typedListener.EnterInit(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IArrayInitListener typedListener = listener as IArrayInitListener;
			if (typedListener != null) typedListener.ExitInit(this);
		}
	}

	[RuleVersion(0)]
	public InitContext init() {
		InitContext _localctx = new InitContext(Context, State);
		EnterRule(_localctx, 0, RULE_init);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4;
			Match(T__0);
			State = 5;
			value();
			State = 10;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__1) {
				{
				{
				State = 6;
				Match(T__1);
				State = 7;
				value();
				}
				}
				State = 12;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 13;
			Match(T__2);
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

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public InitContext init() {
			return GetRuleContext<InitContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(ArrayInitParser.INT, 0); }
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IArrayInitListener typedListener = listener as IArrayInitListener;
			if (typedListener != null) typedListener.EnterValue(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IArrayInitListener typedListener = listener as IArrayInitListener;
			if (typedListener != null) typedListener.ExitValue(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 2, RULE_value);
		try {
			State = 17;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__0:
				EnterOuterAlt(_localctx, 1);
				{
				State = 15;
				init();
				}
				break;
			case INT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 16;
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
		4,1,5,20,2,0,7,0,2,1,7,1,1,0,1,0,1,0,1,0,5,0,9,8,0,10,0,12,0,12,9,0,1,
		0,1,0,1,1,1,1,3,1,18,8,1,1,1,0,0,2,0,2,0,0,19,0,4,1,0,0,0,2,17,1,0,0,0,
		4,5,5,1,0,0,5,10,3,2,1,0,6,7,5,2,0,0,7,9,3,2,1,0,8,6,1,0,0,0,9,12,1,0,
		0,0,10,8,1,0,0,0,10,11,1,0,0,0,11,13,1,0,0,0,12,10,1,0,0,0,13,14,5,3,0,
		0,14,1,1,0,0,0,15,18,3,0,0,0,16,18,5,4,0,0,17,15,1,0,0,0,17,16,1,0,0,0,
		18,3,1,0,0,0,2,10,17
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
