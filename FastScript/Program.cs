// See https://aka.ms/new-console-template for more information

using FastScript.Grammar;

Console.WriteLine("Hello, World!");
Lexer lexer = new Lexer("print(\"Hello, World!\")");
string temp = "";
foreach (var token in lexer.Run())
{
    Console.WriteLine("============================");
    Console.WriteLine(token.Name);
    Console.WriteLine(token.Type);
    Console.WriteLine(token.LineNumber);
    Console.WriteLine(token.CharNumber);
    temp = temp + "\"" + token.Name + "\"" + ",";
}
Console.WriteLine("============================");
Console.WriteLine(temp);