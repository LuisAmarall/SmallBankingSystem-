using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;
using SmallBankingSystem.Domain.Models.Entities;

public class Customer
{
    private Customer() { }

    public Customer(Name name, Email email, Password password)
    {
        if (name is null)
            throw new RequiredFieldException("Name cannot be null.");

        if (email is null)
            throw new RequiredFieldException("Email cannot be null.");

        if (password is null)
            throw new RequiredFieldException("Password cannot be null.");

        CustomerId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Name = name;
        Email = email;
        Password = password;

        Account = Account.Create(CustomerId);
    }

    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    public Account Account { get; private set; }

    public void UpdateName(Name newName)
    {
        if (newName is null)
            throw new RequiredFieldException("Name cannot be null.");

        if (Name.Equals(newName))
            throw new InvalidValueObjectException("New name must be different from current name.");

        Name = newName;
    }

    public void UpdateEmail(Email newEmail)
    {
        if (newEmail is null)
            throw new RequiredFieldException("Email cannot be null.");

        if (Email.Equals(newEmail))
            throw new InvalidValueObjectException("New email must be different from current email.");

        Email = newEmail;
    }

    public void UpdatePassword(Password newPassword)
    {
        if (newPassword is null)
            throw new RequiredFieldException("Password cannot be null.");

        if (Password.Equals(newPassword))
            throw new InvalidValueObjectException("New password must be different from current password.");

        Password = newPassword;
    }
}