namespace finance_manager;

public class User
{
    public User()
    {
    }

    public User(string name, string surname, string email, string password, DateTime birthDate) : base()
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }
    
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Account> Accounts { get; } = new List<Account>();
    
    public bool IsAdmin { get; private set; }

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