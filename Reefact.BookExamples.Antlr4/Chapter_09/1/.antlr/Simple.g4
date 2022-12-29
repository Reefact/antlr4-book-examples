grammar Simple;
@members {
	private readonly List<string> _output = new();

	public IEnumerable<string> GetOutput() => _output;
}

prog		:	classDef+ ;										// match one or more class definitions

classDef	:	'class' ID '{' member+ '}'						// a class has one or more members
				{ _output.Add("class " + $ID.text); }
			;

member		:	'int' ID ';'									// field definition
				{ _output.Add("var " + $ID.text); }
			|	'int' f=ID '(' ID ')' '{' stat '}'			// method definition
				{ _output.Add("method: " + $f.text); }
			;

stat		:	expr ';'
				{ _output.Add("found expr: " + $expr.text); }
			|	ID '=' expr ';'
				{ _output.Add($"found assign: {$ID.text}={$expr.text}"); }
			;

expr		:	INT
			|	ID '(' INT ')'
			;

INT			:	[0-9]+ ;
ID			:	[a-zA-Z]+ ;
WS			:	[ \t\r\n]+ -> skip ;