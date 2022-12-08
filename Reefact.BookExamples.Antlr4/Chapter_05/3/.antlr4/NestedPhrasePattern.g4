grammar NestedPhrasePattern;

expr	:	ID '[' expr ']'		//	a[1], a[b[1]], a[(1)], a[b[(1)]]
		|	'(' expr ')'		//	(a[1]), (a[1]), (((1)))
		|	INT					//	1, 94240
		;

ID      :   [a-zA-Z]+ ;     // match identifiers
INT		:	[0-9]+ ;		// match integers