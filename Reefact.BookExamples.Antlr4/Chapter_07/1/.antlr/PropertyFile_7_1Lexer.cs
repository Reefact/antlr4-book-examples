//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PropertyFile_7_1.g4 by ANTLR 4.11.1

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
public partial class PropertyFile_7_1Lexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, ID=4, STRING=5;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "ID", "STRING"
	};


		protected virtual void StartFile() { } // blank implementations
		protected virtual void FinishFile() { }
		protected virtual void DefineProperty(IToken name, IToken value) { }


	public PropertyFile_7_1Lexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public PropertyFile_7_1Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'='", "'\\r'", "'\\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "ID", "STRING"
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

	public override string GrammarFileName { get { return "PropertyFile_7_1.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static PropertyFile_7_1Lexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,5,31,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,1,0,1,0,1,1,1,1,
		1,2,1,2,1,3,4,3,19,8,3,11,3,12,3,20,1,4,1,4,5,4,25,8,4,10,4,12,4,28,9,
		4,1,4,1,4,1,26,0,5,1,1,3,2,5,3,7,4,9,5,1,0,1,1,0,97,122,32,0,1,1,0,0,0,
		0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,1,11,1,0,0,0,3,13,1,0,
		0,0,5,15,1,0,0,0,7,18,1,0,0,0,9,22,1,0,0,0,11,12,5,61,0,0,12,2,1,0,0,0,
		13,14,5,13,0,0,14,4,1,0,0,0,15,16,5,10,0,0,16,6,1,0,0,0,17,19,7,0,0,0,
		18,17,1,0,0,0,19,20,1,0,0,0,20,18,1,0,0,0,20,21,1,0,0,0,21,8,1,0,0,0,22,
		26,5,34,0,0,23,25,9,0,0,0,24,23,1,0,0,0,25,28,1,0,0,0,26,27,1,0,0,0,26,
		24,1,0,0,0,27,29,1,0,0,0,28,26,1,0,0,0,29,30,5,34,0,0,30,10,1,0,0,0,3,
		0,20,26,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
