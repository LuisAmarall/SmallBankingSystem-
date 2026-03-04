using DomainDesign.ValueObjects;
using SmallBankingSystem.Application.Contracts.Requests.Customer;
using SmallBankingSystem.Application.Contracts.Responses.Customer;

namespace SmallBankingSystem.Application.Mappings.CustomerMappings;

public static class CustomerMappings
{
    public static Customer ToEntity(this CreateCustomerRequest request)
    {
        return new Customer
        (
            new Name(request.IndividualsName),
            new Email(request.Email),
            new Password(request.Key)
        );
    }

    public static CustomerResponse ToResponse(this Customer customer)
    {
        return new CustomerResponse
        (
            customer.CustomerId,
            customer.Name.ToString(),
            customer.Email.EmailAddress,
            customer.CreatedAt
        );
    }
}