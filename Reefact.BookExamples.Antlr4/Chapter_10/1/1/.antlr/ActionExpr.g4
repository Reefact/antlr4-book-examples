grammar ActionExpr;

@header {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

namespace Reefact.BookExamples.Antlr4.Chapter_10._1._1;
}

@parser::members {
	// "memory" for our calculator; variable/value pairs go here
	private readonly Dictionary<string, int> _memory = new Dictionary<string, int>();

	public int Eval(int left, int op, int right) {
		switch(op) {
			case MUL: return left * right;
			case DIV: return left / right;
			case ADD: return left + right;
			case SUB: return left - right;
			default: throw new ArgumentOutOfRangeException();
		}
	}
}

prog		:   stat+ ;

stat		:	expr NEWLINE			{ Console.WriteLine($expr.v); }
			|	ID '=' expr NEWLINE		{ _memory.Add($ID.text, $expr.v); }
			|	NEWLINE
			;

expr returns [int v]	:	a=expr op=(MUL|DIV) b=expr	{ $v = Eval($a.v, $op.type, $b.v); }
						|	a=expr op=(ADD|SUB) b=expr	{ $v = Eval($a.v, $op.type, $b.v); }
						|	INT							{ $v = $INT.int; }
						|	ID
							{
								string id = $ID.text;
								$v = _memory.ContainsKey(id) ? _memory[id] : 0;
							}
						| '(' expr ')'					{ $v = $expr.v; }
						;
 


ID      :   [a-zA-Z]+ ;     // match identifiers
INT     :   [0-9]+ ;        // match integers
NEWLINE :   '\r'? '\n';     // return newlines to parser (is end-statement signal)
WS      :   [ \t]+ -> skip; // toss out whitespaces
MUL     :   '*' ;           // assigns token name to '*' used above in grammar
DIV     :   '/' ;
ADD     :   '+' ;
SUB     :   '-' ;

