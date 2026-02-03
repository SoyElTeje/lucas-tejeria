namespace finance_manager;

public class ClientUser : User
{
    public ClientUser()
    {
    }

    public ClientUser(string name, string surname, string email, string password, DateTime birthDate) : base()
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }
    
    public override string Id { get; set; }
    public override string Name { get; set; }
    public override string Surname { get; set; }
    public override string Email { get; set; }
    public override string Password { get; set; }
    public override string Role { get; set; } = "ClientUser";
    public DateTime BirthDate { get; set; }
    public List<Account> Accounts { get; } = new List<Account>();

    public void CreateAccount(Account account)
    {
        Accounts.Add(account);
    }

    public int GetAge()
    {
        DateTime now = DateTime.Now;
        int age = now.Year - BirthDate.Year;
        if (BirthDate.Date > now.AddYears(-age))
        {
            age--;
        }
        return age;
    }
}