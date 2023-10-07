// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using FastScript.Grammar;

Console.WriteLine("Hello, World!");
Lexer lexer = new Lexer(" print(\"Hello\\\", World!\");\nadd(114514);\nsub(114514.0);\ntest(1.23e+08);\nmul(19.19810);\ntest3(1.23e9);");
string temp = "";
foreach (var token in lexer.Run())
{
    Console.WriteLine("============================");
    Console.WriteLine(token.Name);
    Console.WriteLine(token.Type);
    Console.WriteLine(token.LineNumber);
    Console.WriteLine(token.CharNumber);
    // temp = temp + "\"" + token.Name + "\"" + ",";
    temp = temp + "\n" + token.Name;
}
Console.WriteLine("============================");
Console.WriteLine(temp);
//Console.WriteLine(Regex.Match("\"hello\\\"world\"","\"([^\"\\\\]*(?:\\\\.[^\"\\\\]*)*)\""));

