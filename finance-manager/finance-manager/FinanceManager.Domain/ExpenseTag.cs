namespace finance_manager;

public class ExpenseTag
{
    public ExpenseTag()
    {
    }

    public ExpenseTag(User creator, string name, string description, Color color, string iconUrl)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        ColorId = color.Id;
        Color = color;
        IconUrl = iconUrl;
        Creator = creator;
    }

    public string Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColorId { get; set; }
    public Color Color { get; private set; }
    public string IconUrl { get; set; }
    public User Creator { get; private set; }
}