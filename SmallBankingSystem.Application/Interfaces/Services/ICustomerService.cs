using SmallBankingSystem.Application.Contracts.Requests.Customer;
using SmallBankingSystem.Application.Contracts.Responses.Customer;

namespace SmallBankingSystem.Application.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomerResponse> CreateAsync(CreateCustomerRequest request);

    Task<CustomerResponse?> GetByIdAsync(Guid id);
}