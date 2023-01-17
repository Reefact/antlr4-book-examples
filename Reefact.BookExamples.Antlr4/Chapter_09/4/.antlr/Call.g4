grammar Call;

stat		:	fcall ';' ; 
fcall		:	ID '(' expr ')'
			|	ID '(' expr ')' ')' { NotifyErrorListeners("Too many parentheses."); }
			|	ID '(' expr { NotifyErrorListeners ("Missing closing ')'."); }
			;
expr		:	'(' expr ')'
			|	INT
			;

ID			:   [a-zA-Z]+ ;
INT			:	[0-9]+ ;