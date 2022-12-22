grammar PropertyFile;
@members {
	protected virtual void StartFile() { } // blank implementations
	protected virtual void FinishFile() { }
	protected virtual void DefineProperty(IToken name, IToken value) { }
}
file	:	{StartFile();} prop+ {FinishFile();} ;
prop	:	ID '=' STRING '\r'? '\n' {DefineProperty($ID, $STRING);} ;
ID		:	[a-z]+ ;
STRING	:	'"' .*? '"' ;