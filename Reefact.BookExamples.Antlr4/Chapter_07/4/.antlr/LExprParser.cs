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
public partial class LExprParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, INT=3;
	public const int
		RULE_s = 0, RULE_e = 1;
	public static readonly string[] ruleNames = {
		"s", "e"
	};

	private static readonly string[] _LiteralNames = {
		null, "'*'", "'+'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "INT"
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

	public override string GrammarFileName { get { return "LExpr.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static LExprParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public LExprParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public LExprParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class SContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public EContext e() {
			return GetRuleContext<EContext>(0);
		}
		public SContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_s; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.EnterS(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.ExitS(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILExprVisitor<TResult> typedVisitor = visitor as ILExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitS(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SContext s() {
		SContext _localctx = new SContext(Context, State);
		EnterRule(_localctx, 0, RULE_s);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4;
			e(0);
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

	public partial class EContext : ParserRuleContext {
		public EContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_e; } }
	 
		public EContext() { }
		public virtual void CopyFrom(EContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class AddContext : EContext {
		[System.Diagnostics.DebuggerNonUserCode] public EContext[] e() {
			return GetRuleContexts<EContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public EContext e(int i) {
			return GetRuleContext<EContext>(i);
		}
		public AddContext(EContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.EnterAdd(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.ExitAdd(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILExprVisitor<TResult> typedVisitor = visitor as ILExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAdd(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MultContext : EContext {
		[System.Diagnostics.DebuggerNonUserCode] public EContext[] e() {
			return GetRuleContexts<EContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public EContext e(int i) {
			return GetRuleContext<EContext>(i);
		}
		public MultContext(EContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.EnterMult(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.ExitMult(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILExprVisitor<TResult> typedVisitor = visitor as ILExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMult(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IntContext : EContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(LExprParser.INT, 0); }
		public IntContext(EContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.EnterInt(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ILExprListener typedListener = listener as ILExprListener;
			if (typedListener != null) typedListener.ExitInt(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILExprVisitor<TResult> typedVisitor = visitor as ILExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInt(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public EContext e() {
		return e(0);
	}

	private EContext e(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		EContext _localctx = new EContext(Context, _parentState);
		EContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_e, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			{
			_localctx = new IntContext(_localctx);
			Context = _localctx;
			_prevctx = _localctx;

			State = 7;
			Match(INT);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 17;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 15;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
					case 1:
						{
						_localctx = new MultContext(new EContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_e);
						State = 9;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 10;
						Match(T__0);
						State = 11;
						e(4);
						}
						break;
					case 2:
						{
						_localctx = new AddContext(new EContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_e);
						State = 12;
						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
						State = 13;
						Match(T__1);
						State = 14;
						e(3);
						}
						break;
					}
					} 
				}
				State = 19;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return e_sempred((EContext)_localctx, predIndex);
		}
		return true;
	}
	private bool e_sempred(EContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 3);
		case 1: return Precpred(Context, 2);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,3,21,2,0,7,0,2,1,7,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,
		1,16,8,1,10,1,12,1,19,9,1,1,1,0,1,2,2,0,2,0,0,20,0,4,1,0,0,0,2,6,1,0,0,
		0,4,5,3,2,1,0,5,1,1,0,0,0,6,7,6,1,-1,0,7,8,5,3,0,0,8,17,1,0,0,0,9,10,10,
		3,0,0,10,11,5,1,0,0,11,16,3,2,1,4,12,13,10,2,0,0,13,14,5,2,0,0,14,16,3,
		2,1,3,15,9,1,0,0,0,15,12,1,0,0,0,16,19,1,0,0,0,17,15,1,0,0,0,17,18,1,0,
		0,0,18,3,1,0,0,0,19,17,1,0,0,0,2,15,17
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
