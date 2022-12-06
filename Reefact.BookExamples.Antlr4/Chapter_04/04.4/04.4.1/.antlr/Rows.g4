grammar Rows;

@parser::members { // add members to generated RowsParse
	private readonly int _indexOfTheColumnToDisplay;
	private readonly List<string> _rows = new();

	public RowsParser(ITokenStream input, int indexOfTheColumnToDisplay): this(input) { // custom constructor
		_indexOfTheColumnToDisplay = indexOfTheColumnToDisplay;
	}

	public IEnumerable<string> GetColumnRows() => _rows;
}

file	:	(row NEWLINE)+ ;

row
locals [int i=0]
		:	(
				STUFF
				{
					if ($i == _indexOfTheColumnToDisplay) { _rows.Add($STUFF.text); }

					$i++;
				}
			)+
		;

TAB		:	'\t' -> skip ;	// match but don't pass to the parser
NEWLINE	:	'\r'? '\n' ;	// match and pass to the parser
STUFF	:	~[\t\r\n]+ ;	// match any chars except tab and newline