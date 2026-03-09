using Microsoft.AspNetCore.Mvc;
using SmallBankingSystem.Application.Interfaces.Services;
using SmallBankingSystem.Application.Contracts.Responses.Transfer;
using SmallBankingSystem.Application.Contracts.Requests.Transfer;

namespace SmallBankingSystem.API.Controllers.Transfers;

[ApiController]
[Route("api/[controller]")]
public sealed class TransfersController : ControllerBase
{
    public TransfersController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    private readonly ITransferService _transferService;

    /// <summary>
    /// Retrieves a transfer by its ID.
    /// </summary>
    /// <param name="id">Transfer identifier</param>
    /// <response code="200">Transfer found</response>
    /// <response code="404">Transfer not found</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TransferResponse>> GetById(Guid id)
    {
        var response = await _transferService.GetByIdAsync(id);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    /// <summary>
    /// Creates a new transfer between two accounts.
    /// </summary>
    /// <remarks>
    /// Example request:
    ///
    ///     POST /api/transfers
    ///     {
    ///        "originAccountId": "guid",
    ///        "targetAccountId": "guid",
    ///        "amount": 100
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Transfer created successfully</response>
    /// <response code="400">Invalid transfer request</response>
    /// <response code="404">Account not found</response>
    /// 
    [ProducesResponseType(typeof(TransferResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult<TransferResponse>> Create(TransferRequest request)
    {
        var response = await _transferService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = response.TransferId }, response);
    }
}