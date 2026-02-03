using System.Text.RegularExpressions;

namespace Shared;

public class Color
{
    public Color(){}

    public Color(string hexCode)
    {
        if (!validateHexColor(hexCode))
        {
            throw new ArgumentException("Invalid hex color code. Use #RRGGBB, RRGGBB, #RGB or RGB.", nameof(hexCode));
        }
        HexCode = hexCode;
    }

    public string HexCode { get; set; }

    private bool validateHexColor(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return false;
        }
        
        return Regex.IsMatch(code.Trim(), @"^#?([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$");
    }
}