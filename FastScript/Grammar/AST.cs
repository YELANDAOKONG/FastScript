namespace FastScript.Grammar;

public class AST
{
    public List<ASTNode> Body { get; set; } = new();
    
}

public class ASTNode
{
    public string Type { get; set; }
    public string Value { get; set; }
    public List<ASTNode> Body { get; set; } = new();
}