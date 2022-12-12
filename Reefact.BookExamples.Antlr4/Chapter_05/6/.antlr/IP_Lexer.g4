grammar IP_Lexer;

file	:	row+ ;							// parser rule matching rows of log file
row		:	IP STRING INT NL ;				// match log file record

IP		:	INT '.' INT '.' INT '.' INT ;	// match IPs in lexer
INT		:	[0-9]+ ;						// match IP octet or HTTP result code
STRING	:	'"' .*? '"' ;					// matches the HTTP protocol command
NL		:	'\r'? '\n' ;					// match log file record terminator
WS		:	[ \t] -> skip ;					// ignore spaces