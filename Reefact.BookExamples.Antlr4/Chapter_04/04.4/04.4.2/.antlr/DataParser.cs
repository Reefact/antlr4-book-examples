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
public partial class DataParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INT=1, WS=2;
	public const int
		RULE_file = 0, RULE_group = 1, RULE_sequence = 2;
	public static readonly string[] ruleNames = {
		"file", "group", "sequence"
	};

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "INT", "WS"
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

	public override string GrammarFileName { get { return "Data.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static DataParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public DataParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public DataParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public GroupContext[] group() {
			return GetRuleContexts<GroupContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public GroupContext group(int i) {
			return GetRuleContext<GroupContext>(i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.EnterFile(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.ExitFile(this);
		}
	}

	[RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
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
				group();
				}
				}
				State = 9;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==INT );
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

	public partial class GroupContext : ParserRuleContext {
		public IToken _INT;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(DataParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public SequenceContext sequence() {
			return GetRuleContext<SequenceContext>(0);
		}
		public GroupContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_group; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.EnterGroup(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.ExitGroup(this);
		}
	}

	[RuleVersion(0)]
	public GroupContext group() {
		GroupContext _localctx = new GroupContext(Context, State);
		EnterRule(_localctx, 2, RULE_group);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 11;
			_localctx._INT = Match(INT);
			State = 12;
			sequence((_localctx._INT!=null?int.Parse(_localctx._INT.Text):0));
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

	public partial class SequenceContext : ParserRuleContext {
		public int n;
		public int i = 1;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] INT() { return GetTokens(DataParser.INT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT(int i) {
			return GetToken(DataParser.INT, i);
		}
		public SequenceContext(ParserRuleContext parent, int invokingState) : base(parent, invokingState) { }
		public SequenceContext(ParserRuleContext parent, int invokingState, int n)
			: base(parent, invokingState)
		{
			this.n = n;
		}
		public override int RuleIndex { get { return RULE_sequence; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.EnterSequence(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IDataListener typedListener = listener as IDataListener;
			if (typedListener != null) typedListener.ExitSequence(this);
		}
	}

	[RuleVersion(0)]
	public SequenceContext sequence(int n) {
		SequenceContext _localctx = new SequenceContext(Context, State, n);
		EnterRule(_localctx, 4, RULE_sequence);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 19;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					State = 14;
					if (!(_localctx.i<=_localctx.n)) throw new FailedPredicateException(this, "$i<=$n");
					State = 15;
					Match(INT);
					_localctx.i++;
					}
					} 
				}
				State = 21;
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
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return sequence_sempred((SequenceContext)_localctx, predIndex);
		}
		return true;
	}
	private bool sequence_sempred(SequenceContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return _localctx.i<=_localctx.n;
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,2,23,2,0,7,0,2,1,7,1,2,2,7,2,1,0,4,0,8,8,0,11,0,12,0,9,1,1,1,1,1,1,
		1,2,1,2,1,2,5,2,18,8,2,10,2,12,2,21,9,2,1,2,0,0,3,0,2,4,0,0,21,0,7,1,0,
		0,0,2,11,1,0,0,0,4,19,1,0,0,0,6,8,3,2,1,0,7,6,1,0,0,0,8,9,1,0,0,0,9,7,
		1,0,0,0,9,10,1,0,0,0,10,1,1,0,0,0,11,12,5,1,0,0,12,13,3,4,2,0,13,3,1,0,
		0,0,14,15,4,2,0,1,15,16,5,1,0,0,16,18,6,2,-1,0,17,14,1,0,0,0,18,21,1,0,
		0,0,19,17,1,0,0,0,19,20,1,0,0,0,20,5,1,0,0,0,21,19,1,0,0,0,2,9,19
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}