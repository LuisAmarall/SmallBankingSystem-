using SmallBankingSystem.Application.Contracts.Accounts;
using SmallBankingSystem.Application.Interfaces;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Application.Mappings;
using SmallBankingSystem.Application.Validators.Accounts;

namespace SmallBankingSystem.Application.Services
{
    public sealed class AccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public async Task<CreateAccountResponse> CreateAccountRequestAsync(CreateAccountRequest request)
        {
            AccountValidator.Validate(request);

            var account = AccountMappings.ToEntity(request);

            await _accountRepository.AddAsync(account);

            await _unitOfWork.SaveChangesAsync();
            
            return AccountMappings.ToCreateResponse(account);
        }

        public async Task<GetAccountResponse?> GetByIdAsync(Guid accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account is null)
                throw new KeyNotFoundException($"Account with id {accountId} was not found.");

            return AccountMappings.ToGetResponse(account);
        }

        public async Task<GetAccountResponse?> GetByAccountNumberAsync(string accountNuber)
        {
            var account = await _accountRepository.GetByAccountNumberAsync(accountNuber);
            if (account is null)
                throw new KeyNotFoundException($"Account with account number {accountNuber} was not found.");

            return AccountMappings.ToGetResponse(account);
        }
    }
}