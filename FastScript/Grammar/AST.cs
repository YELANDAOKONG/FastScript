namespace FastScript.Grammar;

public class AST
{
    public List<ASTNode> Body { get; set; } = new();


    public void PrintOut()
    {
        Console.WriteLine($"AST: {Body.Count}");
        for (int i = 0; i < Body.Count(); i++)
        {
            Console.WriteLine($"{i}: {Body[i].Type}");
            Console.WriteLine($"{i}: {Body[i].Value}");
            Console.WriteLine($"{i}: {Body[i].Body.Count}");
                     
            
        }
        
    }
    
}

public class ASTNode
{
    public string Type { get; set; }
    public string Value { get; set; }
    public List<ASTNode> Body { get; set; } = new();
}