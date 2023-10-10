// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using FastScript.Grammar;

Console.WriteLine("Hello, World!");
/*Lexer lexer = new Lexer(" print(\"Hello\\\", World!\");\nadd(114514);\nsub(114514.0);\ntest(1.23e+08);\nmul(19.19810);\ntest3(1.23e9);" + 
                        "import a.b; import c.d.e.f.g;");*/
/*Lexer lexer = new Lexer("""
                        print("Hello", World!);
                        add(114514);
                        sub(114514.0);
                        test(1.23e+08);
                        mul(19.19810);
                        test3(1.23e9);
                        function testfunc(int a, int b) ->int{
                            return a + b;
                        }                               
                        """);
*/
StreamReader sr = new StreamReader(@"..\..\..\Test.fst");
Lexer lexer = new Lexer(sr.ReadToEnd());
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
Console.WriteLine("============================");
Parser parser = new Parser(lexer.Run());
Console.WriteLine(parser.Run());
parser.Run().PrintOut();