using financial_banking.Application.DTOs;
using financial_banking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financial_banking.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositAccountDto depositDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var balance = await _transactionService.DepositAccountAsync(depositDto.accountNumber, depositDto.amount);

            if(balance == 0)
                return NotFound();

            return Ok(balance);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto transferDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var success = await _transactionService.TransferAsync(transferDto.fromAccountNumber, transferDto.toAccountNumber, transferDto.amount);

            if(!success)
                return NotFound();

            return Ok(success);
        }
    }
}