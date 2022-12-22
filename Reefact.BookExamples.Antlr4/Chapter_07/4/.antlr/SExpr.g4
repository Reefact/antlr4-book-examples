grammar SExpr;

// The start rule; begin parsing here.
s    :   e ;

e    :   e op='*' e    // Mult is '*'
     |   e op='+' e    // Add is '*'
     |   INT
     ;

INT  :   [0-9]+ ;            // match integers