grammar Cymbol_8_3;

file				:	(functionDecl | varDecl)+ ;

varDecl				:	type ID ('=' expr)? ';' ;

type				:	'float' | 'int' | 'void' ;					// user-defined types

functionDecl		:	type ID '(' formalParameters? ')' block ;	// "void f(int x) { ... }"

formalParameters	:	formalParameter (',' formalParameter)* ;

formalParameter		:	type ID ;

block				:	'{' stat* '}' ;								// possibly empty statement block

stat				:	block
					|	varDecl
					|	'if' expr 'then' stat ('else' stat)?
					|	'return' expr? ';'
					|	expr '=' expr ';'							// assignement
					|	expr ';'									// func call	
                ;

expr				:	ID '(' exprList? ')'    # Call
					|   expr '[' expr ']'       # Index
					|   '-' expr                # Negate
					|   '!' expr                # Not
					|   expr '*' expr           # Mult
					|   expr ('+'|'-') expr     # AddSub
					|   expr '==' expr          # Equal
					|   ID                      # Var
					|   INT                     # Int
					|   '(' expr ')'            # Parens
					;

exprList			:	expr (',' expr)* ;							// arg list

ID					:	LETTER ( LETTER | [0-9])* ;
fragment
	LETTER			:	[a-zA-Z] ;

INT					:   [0-9]+ ;

WS					:   [ \t\r\n]+ -> skip ;

SL_COMMENT      :   '//' .*? '\n' -> skip ;
