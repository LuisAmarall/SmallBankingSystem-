using Microsoft.AspNetCore.Mvc;
using SmallBankingSystem.Application.Interfaces.Services;
using SmallBankingSystem.Application.Contracts.Requests.Customer;
using SmallBankingSystem.Application.Contracts.Responses.Customer;

namespace SmallBankingSystem.API.Controllers.Customers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomersController : ControllerBase
{
    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    private readonly ICustomerService _customerService;
    
    /// <summary>
    /// Retrieves a customer by its ID.
    /// </summary>
    /// <param name="id">Customer identifier</param>
    /// <response code="200">Customer found</response>
    /// <response code="404">Customer not found</response>
    [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerResponse>> GetById(Guid id)
    {
        var response = await _customerService.GetByIdAsync(id);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <remarks>
    /// Example request:
    ///
    ///     POST /api/customers
    ///     {
    ///         "name": "John Doe",
    ///         "email": "john@email.com"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Customer creation request</param>
    /// <response code="201">Customer created successfully</response>
    /// <response code="400">Invalid request data</response>
    [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<CustomerResponse>> Create(CreateCustomerRequest request)
    {
        var response = await _customerService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = response.CustomerId }, response);
    }
}