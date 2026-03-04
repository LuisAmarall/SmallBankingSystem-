
using SmallBankingSystem.Application.Interfaces.Services;
using SmallBankingSystem.Application.Interfaces.Repositories;
using SmallBankingSystem.Application.Mappings.CustomerMappings;
using SmallBankingSystem.Application.Contracts.Requests.Customer;
using SmallBankingSystem.Application.Contracts.Responses.Customer;


namespace SmallBankingSystem.Application.Services;

public sealed class CustomerService : ICustomerService
{
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    private readonly ICustomerRepository _customerRepository;

    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request)
    {
        CustomerValidator.Validate(request);

        var customer = CustomerMappings.ToEntity(request);

        await _customerRepository.AddAsync(customer);

        await _customerRepository.SaveChangesAsync();

        return CustomerMappings.ToResponse(customer);
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null)return null;

        return CustomerMappings.ToResponse(customer);
    }
}