//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from LabeledExpr.g4 by ANTLR 4.11.1

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
public partial class LabeledExprParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, ID=5, INT=6, NEWLINE=7, WS=8, MUL=9, DIV=10, 
		ADD=11, SUB=12;
	public const int
		RULE_prog = 0, RULE_stat = 1, RULE_expr = 2;
	public static readonly string[] ruleNames = {
		"prog", "stat", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, "'clear'", "'='", "'('", "')'", null, null, null, null, "'*'", "'/'", 
		"'+'", "'-'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, "ID", "INT", "NEWLINE", "WS", "MUL", "DIV", 
		"ADD", "SUB"
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

	public override string GrammarFileName { get { return "LabeledExpr.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static LabeledExprParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public LabeledExprParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public LabeledExprParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public StatContext[] stat() {
			return GetRuleContexts<StatContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatContext stat(int i) {
			return GetRuleContext<StatContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProg(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 7;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 6;
				stat();
				}
				}
				State = 9;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( ((_la) & ~0x3f) == 0 && ((1L << _la) & 234L) != 0 );
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

	public partial class StatContext : ParserRuleContext {
		public StatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_stat; } }
	 
		public StatContext() { }
		public virtual void CopyFrom(StatContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class BlankContext : StatContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(LabeledExprParser.NEWLINE, 0); }
		public BlankContext(StatContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlank(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ClearContext : StatContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(LabeledExprParser.NEWLINE, 0); }
		public ClearContext(StatContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClear(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrintExprContext : StatContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(LabeledExprParser.NEWLINE, 0); }
		public PrintExprContext(StatContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AssignContext : StatContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(LabeledExprParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(LabeledExprParser.NEWLINE, 0); }
		public AssignContext(StatContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssign(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatContext stat() {
		StatContext _localctx = new StatContext(Context, State);
		EnterRule(_localctx, 2, RULE_stat);
		try {
			State = 22;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				_localctx = new PrintExprContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 11;
				expr(0);
				State = 12;
				Match(NEWLINE);
				}
				break;
			case 2:
				_localctx = new ClearContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 14;
				Match(T__0);
				State = 15;
				Match(NEWLINE);
				}
				break;
			case 3:
				_localctx = new AssignContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 16;
				Match(ID);
				State = 17;
				Match(T__1);
				State = 18;
				expr(0);
				State = 19;
				Match(NEWLINE);
				}
				break;
			case 4:
				_localctx = new BlankContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 21;
				Match(NEWLINE);
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
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParensContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ParensContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParens(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MulDivContext : ExprContext {
		public IToken op;
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MUL() { return GetToken(LabeledExprParser.MUL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIV() { return GetToken(LabeledExprParser.DIV, 0); }
		public MulDivContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMulDiv(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AddSubContext : ExprContext {
		public IToken op;
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ADD() { return GetToken(LabeledExprParser.ADD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SUB() { return GetToken(LabeledExprParser.SUB, 0); }
		public AddSubContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddSub(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(LabeledExprParser.ID, 0); }
		public IdContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitId(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IntContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(LabeledExprParser.INT, 0); }
		public IntContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabeledExprVisitor<TResult> typedVisitor = visitor as ILabeledExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInt(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 4;
		EnterRecursionRule(_localctx, 4, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 31;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				{
				_localctx = new IntContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 25;
				Match(INT);
				}
				break;
			case ID:
				{
				_localctx = new IdContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 26;
				Match(ID);
				}
				break;
			case T__2:
				{
				_localctx = new ParensContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 27;
				Match(T__2);
				State = 28;
				expr(0);
				State = 29;
				Match(T__3);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 41;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,4,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 39;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
					case 1:
						{
						_localctx = new MulDivContext(new ExprContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 33;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 34;
						((MulDivContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==MUL || _la==DIV) ) {
							((MulDivContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 35;
						expr(6);
						}
						break;
					case 2:
						{
						_localctx = new AddSubContext(new ExprContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 36;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 37;
						((AddSubContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==ADD || _la==SUB) ) {
							((AddSubContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 38;
						expr(5);
						}
						break;
					}
					} 
				}
				State = 43;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,4,Context);
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
		case 2: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 5);
		case 1: return Precpred(Context, 4);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,12,45,2,0,7,0,2,1,7,1,2,2,7,2,1,0,4,0,8,8,0,11,0,12,0,9,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,23,8,1,1,2,1,2,1,2,1,2,1,2,1,2,1,
		2,3,2,32,8,2,1,2,1,2,1,2,1,2,1,2,1,2,5,2,40,8,2,10,2,12,2,43,9,2,1,2,0,
		1,4,3,0,2,4,0,2,1,0,9,10,1,0,11,12,49,0,7,1,0,0,0,2,22,1,0,0,0,4,31,1,
		0,0,0,6,8,3,2,1,0,7,6,1,0,0,0,8,9,1,0,0,0,9,7,1,0,0,0,9,10,1,0,0,0,10,
		1,1,0,0,0,11,12,3,4,2,0,12,13,5,7,0,0,13,23,1,0,0,0,14,15,5,1,0,0,15,23,
		5,7,0,0,16,17,5,5,0,0,17,18,5,2,0,0,18,19,3,4,2,0,19,20,5,7,0,0,20,23,
		1,0,0,0,21,23,5,7,0,0,22,11,1,0,0,0,22,14,1,0,0,0,22,16,1,0,0,0,22,21,
		1,0,0,0,23,3,1,0,0,0,24,25,6,2,-1,0,25,32,5,6,0,0,26,32,5,5,0,0,27,28,
		5,3,0,0,28,29,3,4,2,0,29,30,5,4,0,0,30,32,1,0,0,0,31,24,1,0,0,0,31,26,
		1,0,0,0,31,27,1,0,0,0,32,41,1,0,0,0,33,34,10,5,0,0,34,35,7,0,0,0,35,40,
		3,4,2,6,36,37,10,4,0,0,37,38,7,1,0,0,38,40,3,4,2,5,39,33,1,0,0,0,39,36,
		1,0,0,0,40,43,1,0,0,0,41,39,1,0,0,0,41,42,1,0,0,0,42,5,1,0,0,0,43,41,1,
		0,0,0,5,9,22,31,39,41
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
