using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Domain.Models.VOsInSln;
using SmallBankingSystem.Application.Interfaces;
using SmallBankingSystem.Application.Mappings.Transfers;
using SmallBankingSystem.Application.Contracts.Transfers;
using SmallBankingSystem.Application.Validators.Transfers;
using SmallBankingSystem.Application.Interfaces.Persistence;

namespace SmallBankingSystem.Application.Services;

public sealed class TransferService
{
    public TransferService(IUnitOfWork unitOfWork, IAccountRepository accountRepository, ITransferRepository transferRepository)
    {
        _unitOfWork = unitOfWork;
        _accountRepository = accountRepository;
        _transferRepository = transferRepository;
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransferRepository _transferRepository;
    
    public async Task<TransferResponse> TransferAsync(CreateTransferRequest request)
    {
        TransferValidator.Validate(request);

        var sourceAccount = await _accountRepository.GetByIdAsync(request.SourceAccountId);
        var targetAccount = await _accountRepository.GetByIdAsync(request.TargetAccountId);

        if (sourceAccount is null)
            throw new RequiredFieldException($"{nameof(request.SourceAccountId)}: Please note that the source account id field does not reference an existing account.");
        if (targetAccount is null)
            throw new RequiredFieldException($"{nameof(request.TargetAccountId)}: Please note that the target account id field does not reference an existing account.");

        var amount = new Money(request.Amount);
        sourceAccount.TransferTo(targetAccount, amount);

        var transfer = new Transfer(
            sourceAccount.AccountId,
            targetAccount.AccountId,
            request.Amount);

        await _transferRepository.AddAsync(transfer);
        
        await _unitOfWork.SaveChangesAsync();
        
        return transfer.ToResponse();
    }
}
