grammar PropertyFile_7_2;

file	:	prop+ ;
prop	:	ID '=' STRING NEWLINE ;

ID		:	[a-z]+ ;
STRING	:	'"' .*? '"' ;
NEWLINE	:	'\r'? '\n' ; 