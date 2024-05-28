using System.ComponentModel;

namespace ai_code_challenger.common.Enums;

public enum ESupportedLanguages
{
    [Description("C")]
    C = 1,
    
    [Description("C#")]
    Cs = 2,
    
    [Description("C++")]
    Cpp = 3,
    
    [Description("Java")]
    Java = 4,

    [Description("Javascript")]
    Js = 5,

    [Description("Python")]
    Py = 6
}
