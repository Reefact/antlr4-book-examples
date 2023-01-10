grammar VecMsg;

vec4	:		'[' ints[4] ']' ;
ints[int max]
locals [int i=1]
		:		INT ( ',' {$i++;} {$i<=$max}?<fail={"exceed max "+$max}> INT )*
		;

INT     :   [0-9]+ ;