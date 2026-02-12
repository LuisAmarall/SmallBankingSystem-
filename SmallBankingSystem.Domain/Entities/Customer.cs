using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;

namespace SmallBanking.Domain.Entities;

public class Customer
{
    private Customer() { }

    public Customer(Guid customerId, DateTime createdAt, Name name, Email email, Password password)
    {
        CustomerId = customerId;
        CreatedAt = createdAt;
        Name = name;
        Email = email;
        Password = password;
    }

    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }


    public void UpdateName(Name newName)
    {
        if (newName is null)
            throw new RequiredFieldException($"{nameof(newName)}: Please note that the name field does not allow null values.");
        if (Name != null && Name.Equals(newName))
            throw new InvalidValueObjectException($"{nameof(newName)}: Sorry, but this name is already in use.");

        Name = newName;
    }

    public void UpdateEmail(Email newEmail)
    {
        if (newEmail is null)
            throw new RequiredFieldException($"{nameof(newEmail)}: Please note that the email field does not allow null values.");
        if (Email != null && Email.Equals(newEmail))
            throw new InvalidValueObjectException($"{nameof(newEmail)}: Sorry, but this email is already in use.");

        Email = newEmail;
    }

    public void UpdatePassword(Password newPassword)
    {
        if (newPassword is null)
            throw new RequiredFieldException($"{nameof(newPassword)}: Please note that the password field does not allow null values.");
        if (Password != null && Password.Equals(newPassword))
            throw new InvalidValueObjectException($"{nameof(newPassword)}: Sorry, but this password is already in use.");

        Password = newPassword;
    }

    //Inject the soft delete and reactive methods using dependency injection.
}