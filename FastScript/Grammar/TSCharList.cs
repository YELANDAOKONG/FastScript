namespace FastScript.Grammar;

public class TSCharList
{
    public static readonly List<string> TCL = new List<string>()
    {
        " ",
        "\n",
        "\t",
        "\r",
        ":",
        ";",
        "(",
        ")",
        "[",
        "]",
        "{",
        "}",
        ",",
        ".",
        "?",
        "/",
        "\\",
        "|",
        "+",
        "-",
        "*",
        "%",
        "^",
        "&",
        "~",
        "!",
        "=",
        "<",
        ">",
        "@",
        "#",
        "$",
    };

    public static readonly List<string> SCL = new List<string>()
    {
        " ",
        "\n",
        "\t",
        "\r",
    };
}