//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from IP_Parser.g4 by ANTLR 4.11.1

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class IP_ParserLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, INT=2, STRING=3, NL=4, WS=5;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "INT", "STRING", "NL", "WS"
	};


	public IP_ParserLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public IP_ParserLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "INT", "STRING", "NL", "WS"
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

	public override string GrammarFileName { get { return "IP_Parser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static IP_ParserLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,5,36,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,1,0,1,0,1,1,4,1,
		15,8,1,11,1,12,1,16,1,2,1,2,5,2,21,8,2,10,2,12,2,24,9,2,1,2,1,2,1,3,3,
		3,29,8,3,1,3,1,3,1,4,1,4,1,4,1,4,1,22,0,5,1,1,3,2,5,3,7,4,9,5,1,0,2,1,
		0,48,57,2,0,9,9,32,32,38,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,
		0,0,9,1,0,0,0,1,11,1,0,0,0,3,14,1,0,0,0,5,18,1,0,0,0,7,28,1,0,0,0,9,32,
		1,0,0,0,11,12,5,46,0,0,12,2,1,0,0,0,13,15,7,0,0,0,14,13,1,0,0,0,15,16,
		1,0,0,0,16,14,1,0,0,0,16,17,1,0,0,0,17,4,1,0,0,0,18,22,5,34,0,0,19,21,
		9,0,0,0,20,19,1,0,0,0,21,24,1,0,0,0,22,23,1,0,0,0,22,20,1,0,0,0,23,25,
		1,0,0,0,24,22,1,0,0,0,25,26,5,34,0,0,26,6,1,0,0,0,27,29,5,13,0,0,28,27,
		1,0,0,0,28,29,1,0,0,0,29,30,1,0,0,0,30,31,5,10,0,0,31,8,1,0,0,0,32,33,
		7,1,0,0,33,34,1,0,0,0,34,35,6,4,0,0,35,10,1,0,0,0,4,0,16,22,28,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
