using SmallBankingSystem.Application.Contracts.Requests.Transfer;
using SmallBankingSystem.Application.Contracts.Responses.Transfer;

namespace SmallBankingSystem.Application.Interfaces.Services;

public interface ITransferService
{
    Task<TransferResponse> CreateAsync(TransferRequest request);
}