grammar LExpr;

// The start rule; begin parsing here.
s    :   e ;

e    :   e '*' e    #Mult
     |   e '+' e    #Add
     |   INT        #Int
     ;

INT     :   [0-9]+ ;            // match integers