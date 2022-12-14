//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Vec.g4 by ANTLR 4.11.1

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
public partial class VecParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, INT=4;
	public const int
		RULE_vec4 = 0, RULE_ints = 1;
	public static readonly string[] ruleNames = {
		"vec4", "ints"
	};

	private static readonly string[] _LiteralNames = {
		null, "'['", "']'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "INT"
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

	public override string GrammarFileName { get { return "Vec.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static VecParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public VecParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public VecParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class Vec4Context : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public IntsContext ints() {
			return GetRuleContext<IntsContext>(0);
		}
		public Vec4Context(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_vec4; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IVecListener typedListener = listener as IVecListener;
			if (typedListener != null) typedListener.EnterVec4(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IVecListener typedListener = listener as IVecListener;
			if (typedListener != null) typedListener.ExitVec4(this);
		}
	}

	[RuleVersion(0)]
	public Vec4Context vec4() {
		Vec4Context _localctx = new Vec4Context(Context, State);
		EnterRule(_localctx, 0, RULE_vec4);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4;
			Match(T__0);
			State = 5;
			ints(4);
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

	public partial class IntsContext : ParserRuleContext {
		public int max;
		public int i = 1;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] INT() { return GetTokens(VecParser.INT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT(int i) {
			return GetToken(VecParser.INT, i);
		}
		public IntsContext(ParserRuleContext parent, int invokingState) : base(parent, invokingState) { }
		public IntsContext(ParserRuleContext parent, int invokingState, int max)
			: base(parent, invokingState)
		{
			this.max = max;
		}
		public override int RuleIndex { get { return RULE_ints; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IVecListener typedListener = listener as IVecListener;
			if (typedListener != null) typedListener.EnterInts(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IVecListener typedListener = listener as IVecListener;
			if (typedListener != null) typedListener.ExitInts(this);
		}
	}

	[RuleVersion(0)]
	public IntsContext ints(int max) {
		IntsContext _localctx = new IntsContext(Context, State, max);
		EnterRule(_localctx, 2, RULE_ints);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 8;
			Match(INT);
			State = 15;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 9;
				Match(T__2);
				_localctx.i++;
				State = 11;
				if (!(_localctx.i<=_localctx.max)) throw new FailedPredicateException(this, "$i<=$max");
				State = 12;
				Match(INT);
				}
				}
				State = 17;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
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

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return ints_sempred((IntsContext)_localctx, predIndex);
		}
		return true;
	}
	private bool ints_sempred(IntsContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return _localctx.i<=_localctx.max;
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,4,19,2,0,7,0,2,1,7,1,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,5,1,14,8,
		1,10,1,12,1,17,9,1,1,1,0,0,2,0,2,0,0,17,0,4,1,0,0,0,2,8,1,0,0,0,4,5,5,
		1,0,0,5,6,3,2,1,0,6,7,5,2,0,0,7,1,1,0,0,0,8,15,5,4,0,0,9,10,5,3,0,0,10,
		11,6,1,-1,0,11,12,4,1,0,1,12,14,5,4,0,0,13,9,1,0,0,0,14,17,1,0,0,0,15,
		13,1,0,0,0,15,16,1,0,0,0,16,3,1,0,0,0,17,15,1,0,0,0,1,15
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
