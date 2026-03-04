using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Domain.Models.VOsInSln;
using SmallBankingSystem.Application.Interfaces.Services;
using SmallBankingSystem.Application.Validators.Transfers;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Application.Interfaces.Repositories;
using SmallBankingSystem.Application.Mappings.TransferMappings;
using SmallBankingSystem.Application.Contracts.Requests.Transfer;
using SmallBankingSystem.Application.Contracts.Responses.Transfer;

namespace SmallBankingSystem.Application.Services;

public sealed class TransferService : ITransferService
{
    

    public TransferService(ICustomerRepository customerRepository, ITransferRepository transferRepository)
    {
        _customerRepository = customerRepository;
        _transferRepository = transferRepository;
    }

    private readonly ICustomerRepository _customerRepository;
    private readonly ITransferRepository _transferRepository;

    public async Task<TransferResponse> CreateAsync(TransferRequest request)
    {
        TransferValidator.Validate(request);

        var sourceCustomerAccount = await _customerRepository.GetByIdAsync(request.OriginAccountId);
        var targetCustomerAccount = await _customerRepository.GetByIdAsync(request.TargetAccountId);

        if (sourceCustomerAccount is null)
            throw new RequiredFieldException($"{nameof(request.OriginAccountId)}: Please note that the source account id field does not reference an existing account.");

        if (targetCustomerAccount is null)
            throw new RequiredFieldException($"{nameof(request.TargetAccountId)}: Please note that the target account id field does not reference an existing account.");

        var sourceAccount = sourceCustomerAccount.Account;
        var targetAccount = targetCustomerAccount.Account;
        var amount = new Money(request.Amount);

        sourceAccount.TransferTo(targetAccount, amount);

        var transfer = new Transfer(
            sourceAccount.AccountId,
            targetAccount.AccountId,
            amount);

        await _transferRepository.AddAsync(transfer);

        await _customerRepository.SaveChangesAsync();

        return TransferMappings.ToResponse(transfer);
    }
}