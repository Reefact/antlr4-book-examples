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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class CSVLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, TEXT=4, STRING=5;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "TEXT", "STRING"
	};


	public CSVLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CSVLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CSVLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,5,33,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,1,0,1,0,1,1,1,1,
		1,2,1,2,1,3,4,3,19,8,3,11,3,12,3,20,1,4,1,4,1,4,1,4,5,4,27,8,4,10,4,12,
		4,30,9,4,1,4,1,4,0,0,5,1,1,3,2,5,3,7,4,9,5,1,0,2,4,0,10,10,13,13,34,34,
		44,44,1,0,34,34,35,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,
		1,0,0,0,1,11,1,0,0,0,3,13,1,0,0,0,5,15,1,0,0,0,7,18,1,0,0,0,9,22,1,0,0,
		0,11,12,5,44,0,0,12,2,1,0,0,0,13,14,5,13,0,0,14,4,1,0,0,0,15,16,5,10,0,
		0,16,6,1,0,0,0,17,19,8,0,0,0,18,17,1,0,0,0,19,20,1,0,0,0,20,18,1,0,0,0,
		20,21,1,0,0,0,21,8,1,0,0,0,22,28,5,34,0,0,23,24,5,34,0,0,24,27,5,34,0,
		0,25,27,8,1,0,0,26,23,1,0,0,0,26,25,1,0,0,0,27,30,1,0,0,0,28,26,1,0,0,
		0,28,29,1,0,0,0,29,31,1,0,0,0,30,28,1,0,0,0,31,32,5,34,0,0,32,10,1,0,0,
		0,4,0,20,26,28,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
