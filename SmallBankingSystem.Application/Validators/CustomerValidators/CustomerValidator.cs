using DomainDesign.Exceptions;
using SmallBankingSystem.Application.Contracts.Requests.Customer;

public static class CustomerValidator
{
    public static void Validate(CreateCustomerRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.IndividualsName))
            throw new RequiredFieldException($"{nameof(request.IndividualsName)}: Please note that the individual's name field does not allow null values.");

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new RequiredFieldException($"{nameof(request.Email)}: Please note that the email field does not allow null values.");

        if (string.IsNullOrWhiteSpace(request.Key))
            throw new RequiredFieldException($"{nameof(request.Key)}: Please note that the key field does not allow null values.");
    }
}