grammar IP_Parser;

file	:	row+ ;							// parser rule matching rows of log file
row		:	ip STRING INT NL ;				// match log file record
ip		:	INT '.' INT '.' INT '.' INT ;	// match IPs in parser

INT		:	[0-9]+ ;						// match IP octet or HTTP result code
STRING	:	'"' .*? '"' ;					// matches the HTTP protocol command
NL		:	'\r'? '\n' ;					// match log file record terminator
WS		:	[ \t] -> skip ;					// ignore spaces