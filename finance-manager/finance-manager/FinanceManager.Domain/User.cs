namespace finance_manager;

public abstract class User
{
    protected User()
    {
    }
    
    public abstract string Id { get; set; }
    public abstract string Name { get; set; }
    public abstract string Surname { get; set; }
    public abstract string Email { get; set; }
    public abstract string Password { get; set; }
    public abstract string Role { get; set; }
}