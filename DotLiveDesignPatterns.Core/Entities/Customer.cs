namespace DotLiveDesignPatterns.Core.Entities;

public class Customer
{
    public Customer(string fullName, DateTime birthDate, string email)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        BirthDate = birthDate;

        Email = email;
    }

    public Guid Id { get; private set; }

    public string FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public CustomerStatus Status { get; private set; }
    public string Email { get; private set; }
        
    public bool IsAllowedToBuy()
    {
        return Status != CustomerStatus.Blocked;
    }
}

public enum CustomerStatus
{
    Active = 1,
    Blocked = 2,
    Restricted = 3,
    Cancelled = 4
}