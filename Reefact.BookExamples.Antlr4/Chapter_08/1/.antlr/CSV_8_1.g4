grammar CSV_8_1;

file	:	hdr row+ ;
hdr		:	row ;
row		:	field (',' field)* '\r'? '\n' ;
field	:	TEXT	# Text
		|	STRING	# String
		|			# Empty
		;

TEXT	:	~[,\n\r"]+ ;
STRING	:	'"' ('""' | ~'"')* '"' ;