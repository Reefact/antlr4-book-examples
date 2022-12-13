//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CSV.g4 by ANTLR 4.11.1

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
public partial class CSVParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, TEXT=4, STRING=5;
	public const int
		RULE_file = 0, RULE_hdr = 1, RULE_row = 2, RULE_field = 3;
	public static readonly string[] ruleNames = {
		"file", "hdr", "row", "field"
	};

	private static readonly string[] _LiteralNames = {
		null, "','", "'\\r'", "'\\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "TEXT", "STRING"
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

	public override string GrammarFileName { get { return "CSV.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CSVParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CSVParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CSVParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public HdrContext hdr() {
			return GetRuleContext<HdrContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public RowContext[] row() {
			return GetRuleContexts<RowContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public RowContext row(int i) {
			return GetRuleContext<RowContext>(i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.EnterFile(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
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
			State = 8;
			hdr();
			State = 10;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 9;
				row();
				}
				}
				State = 12;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( ((_la) & ~0x3f) == 0 && ((1L << _la) & 62L) != 0 );
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

	public partial class HdrContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public RowContext row() {
			return GetRuleContext<RowContext>(0);
		}
		public HdrContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_hdr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.EnterHdr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.ExitHdr(this);
		}
	}

	[RuleVersion(0)]
	public HdrContext hdr() {
		HdrContext _localctx = new HdrContext(Context, State);
		EnterRule(_localctx, 2, RULE_hdr);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 14;
			row();
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

	public partial class RowContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public FieldContext[] field() {
			return GetRuleContexts<FieldContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public FieldContext field(int i) {
			return GetRuleContext<FieldContext>(i);
		}
		public RowContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_row; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.EnterRow(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.ExitRow(this);
		}
	}

	[RuleVersion(0)]
	public RowContext row() {
		RowContext _localctx = new RowContext(Context, State);
		EnterRule(_localctx, 4, RULE_row);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16;
			field();
			State = 21;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__0) {
				{
				{
				State = 17;
				Match(T__0);
				State = 18;
				field();
				}
				}
				State = 23;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 25;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__1) {
				{
				State = 24;
				Match(T__1);
				}
			}

			State = 27;
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

	public partial class FieldContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TEXT() { return GetToken(CSVParser.TEXT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(CSVParser.STRING, 0); }
		public FieldContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_field; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.EnterField(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICSVListener typedListener = listener as ICSVListener;
			if (typedListener != null) typedListener.ExitField(this);
		}
	}

	[RuleVersion(0)]
	public FieldContext field() {
		FieldContext _localctx = new FieldContext(Context, State);
		EnterRule(_localctx, 6, RULE_field);
		try {
			State = 32;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case TEXT:
				EnterOuterAlt(_localctx, 1);
				{
				State = 29;
				Match(TEXT);
				}
				break;
			case STRING:
				EnterOuterAlt(_localctx, 2);
				{
				State = 30;
				Match(STRING);
				}
				break;
			case T__0:
			case T__1:
			case T__2:
				EnterOuterAlt(_localctx, 3);
				{
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
		4,1,5,35,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,1,0,1,0,4,0,11,8,0,11,0,12,0,
		12,1,1,1,1,1,2,1,2,1,2,5,2,20,8,2,10,2,12,2,23,9,2,1,2,3,2,26,8,2,1,2,
		1,2,1,3,1,3,1,3,3,3,33,8,3,1,3,0,0,4,0,2,4,6,0,0,35,0,8,1,0,0,0,2,14,1,
		0,0,0,4,16,1,0,0,0,6,32,1,0,0,0,8,10,3,2,1,0,9,11,3,4,2,0,10,9,1,0,0,0,
		11,12,1,0,0,0,12,10,1,0,0,0,12,13,1,0,0,0,13,1,1,0,0,0,14,15,3,4,2,0,15,
		3,1,0,0,0,16,21,3,6,3,0,17,18,5,1,0,0,18,20,3,6,3,0,19,17,1,0,0,0,20,23,
		1,0,0,0,21,19,1,0,0,0,21,22,1,0,0,0,22,25,1,0,0,0,23,21,1,0,0,0,24,26,
		5,2,0,0,25,24,1,0,0,0,25,26,1,0,0,0,26,27,1,0,0,0,27,28,5,3,0,0,28,5,1,
		0,0,0,29,33,5,4,0,0,30,33,5,5,0,0,31,33,1,0,0,0,32,29,1,0,0,0,32,30,1,
		0,0,0,32,31,1,0,0,0,33,7,1,0,0,0,4,12,21,25,32
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
