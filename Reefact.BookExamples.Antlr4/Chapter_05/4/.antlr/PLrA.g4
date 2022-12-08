grammar PLrA;

calc	:	expr '\r\n' ;

expr	:	<assoc=right> expr '^' expr	# Pow	// ^operator is right associative
		|	expr '*' expr				# Mul		// match subexpressions joined with * operator
		|	expr '+' expr				# Add			// match subexpressions joined with + operator
		|	INT							# Int			// match simple integer atom
		;

INT			: [0-9]+ ;