grammar Language;

// WS : [ \t\r\n]+ -> skip ;
WS
    : [ \t\u000C\r\n]+ -> skip
    ;

DEC_NUMBER :  [0-9]+;
HEX_NUMBER :  '0x' [0-9A-Fa-f]+ ;
OCT_NUMBER :  '0o' [0-7]+ ;
BIN_NUMBER :  '0b' [0-1]+ ;
EXPONENT_PART :  [eE] [+-]? [0-9]+ ;
DEC_POINT_NUMBER :  [0-9]* '.' [0-9]+ ;
FLOAT_NUMBER :  [0-9]* '.' [0-9]+ EXPONENT_PART? ;
DOUBLE_NUMBER :  [0-9]* '.' [0-9]+ EXPONENT_PART 'd' ;

ESCAPE_SEQUENCE :   '\\' [btnfr"'\\] ;
STRING_LITERAL :  '"' (~["\\\r\n] | ESCAPE_SEQUENCE)* '"' ;
CHAR_LITERAL :  '\'' (~['\\\r\n] | ESCAPE_SEQUENCE) '\'' ;

IDENTIFIER :  [a-zA-Z_] [a-zA-Z_0-9]* ;

LINE_COMMENT : '//' .*? '\n' -> channel(HIDDEN) ;
COMMENT : '/*' .*? '*/' -> channel(HIDDEN) ;


expr  :  expr '+' expr
      | expr '-' expr
      | expr '*' expr
      | expr '/' expr
      | expr '%' expr
      | expr '^' expr
      | expr '&' expr
      | expr '|' expr
      | expr '<<' expr
      | expr '>>' expr
      | expr '<' expr
      | expr '>' expr
      | expr '<=' expr
      | expr '>=' expr
      | expr '==' expr
      | expr '!=' expr
      | expr '&&' expr
      | expr '||' expr
      | '!' expr
      | '-' expr
      | '+' expr
      | '~' expr
      | '++' expr
      | '--' expr
      | '*' expr
      | '&' expr
      ;

