using System.Text.RegularExpressions;

namespace finance_manager;

public class Color
{
    public Color()
    {
    }

    public Color(string name, string hexCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Color name is required.", nameof(name));
        if (!ValidateHexColor(hexCode))
            throw new ArgumentException("Invalid hex color code. Use #RRGGBB, RRGGBB, #RGB or RGB.", nameof(hexCode));

        Id = Guid.NewGuid().ToString();
        Name = name;
        HexCode = NormalizeHexCode(hexCode);
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string HexCode { get; set; }

    private static bool ValidateHexColor(string? code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return false;
        return Regex.IsMatch(code.Trim(), @"^#?([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$");
    }

    private static string NormalizeHexCode(string hexCode)
    {
        var trimmed = hexCode.Trim();
        if (trimmed.StartsWith("#"))
            return trimmed;
        return "#" + trimmed;
    }
}
