//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from IP_Lexer.g4 by ANTLR 4.11.1

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
public partial class IP_LexerParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		IP=1, INT=2, STRING=3, NL=4, WS=5;
	public const int
		RULE_file = 0, RULE_row = 1;
	public static readonly string[] ruleNames = {
		"file", "row"
	};

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "IP", "INT", "STRING", "NL", "WS"
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

	public override string GrammarFileName { get { return "IP_Lexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static IP_LexerParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public IP_LexerParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public IP_LexerParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
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
			IIP_LexerListener typedListener = listener as IIP_LexerListener;
			if (typedListener != null) typedListener.EnterFile(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IIP_LexerListener typedListener = listener as IIP_LexerListener;
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
			State = 5;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 4;
				row();
				}
				}
				State = 7;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==IP );
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
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IP() { return GetToken(IP_LexerParser.IP, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(IP_LexerParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(IP_LexerParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NL() { return GetToken(IP_LexerParser.NL, 0); }
		public RowContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_row; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IIP_LexerListener typedListener = listener as IIP_LexerListener;
			if (typedListener != null) typedListener.EnterRow(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IIP_LexerListener typedListener = listener as IIP_LexerListener;
			if (typedListener != null) typedListener.ExitRow(this);
		}
	}

	[RuleVersion(0)]
	public RowContext row() {
		RowContext _localctx = new RowContext(Context, State);
		EnterRule(_localctx, 2, RULE_row);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 9;
			Match(IP);
			State = 10;
			Match(STRING);
			State = 11;
			Match(INT);
			State = 12;
			Match(NL);
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
		4,1,5,15,2,0,7,0,2,1,7,1,1,0,4,0,6,8,0,11,0,12,0,7,1,1,1,1,1,1,1,1,1,1,
		1,1,0,0,2,0,2,0,0,13,0,5,1,0,0,0,2,9,1,0,0,0,4,6,3,2,1,0,5,4,1,0,0,0,6,
		7,1,0,0,0,7,5,1,0,0,0,7,8,1,0,0,0,8,1,1,0,0,0,9,10,5,1,0,0,10,11,5,3,0,
		0,11,12,5,2,0,0,12,13,5,4,0,0,13,3,1,0,0,0,1,7
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}