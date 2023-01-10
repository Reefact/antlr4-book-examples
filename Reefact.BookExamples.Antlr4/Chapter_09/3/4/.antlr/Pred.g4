grammar Pred;

assign	:	ID '=' v=INT { if ($v.int==0) NotifyErrorListeners("values must be > 0"); } ';'
		;

ID      :   [a-zA-Z]+ ;
INT     :   [0-9]+ ;