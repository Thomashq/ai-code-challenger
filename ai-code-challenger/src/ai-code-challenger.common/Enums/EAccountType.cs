using System.ComponentModel;

namespace ai_code_challenger.common.Enums;

public enum EAccountType
{
    [Description("manager")]
    Admin = 1,
    [Description("user")]
    User = 2
}
