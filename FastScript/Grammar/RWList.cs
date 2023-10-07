namespace FastScript.Grammar;

public class RWList
{
    public static readonly Dictionary<string, string> RegexList = new Dictionary<string, string>()
    {
        {"NULL" , @"^null$"},
        {"ID" , @"^[a-zA-Z_][a-zA-Z_0-9]*$"}, 
        
        {"STRING", "\\\"[^\\\"]*\\\""}, //"([^""\\]|\\.)*"  or   \"([^\"\"\\\\]|\\\\.)*\"   or     \"[^\"]*\"             

        {"NUMBER", @"^-?(0|[1-9][0-9]*)(\.[0-9]+)?([eE][+-]?[0-9]+)?$"},
        {"POINT_NUMBER", @"^-?(0|[1-9][0-9]*)(\.[0-9]+)?$"},
        {"BOOL", @"^true$|^false$"},
        
        

        
    };
    public static readonly Dictionary<int, string> WeightList = new Dictionary<int, string>()
    {
        {1, "POINT_NUMBER"},
        {2, "NUMBER"},
        {3, "BOOL"},
        {4, "STRING"},
        
        
        {1000000, "NULL"},
        {1000001, "ID"},
    };
}