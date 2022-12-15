grammar LispStyleTree;

parent_node	:	'(' ID (' ' child_node)+? ')';
child_node	:	parent_node	
            |	ID ;

ID          : ~[ ()]+ ;