using financial_banking.Application.DTOs;
using financial_banking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financial_banking.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto accountDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            var success = await _accountService.CreateAccountAsync(accountDTO.accountNumber, accountDTO.name);

            if (!success)
            {
                return BadRequest("An account with this username already exists.");
            }

            return Ok(accountDTO);
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccount(string accountNumber)
        {
            if(accountNumber == null || accountNumber == "" || accountNumber.Length != 10)
                return BadRequest("Account Number is required and length must be 10");

            
            var account = await _accountService.GetAccountAsync(accountNumber);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("balance/{accountNumber}")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            if(accountNumber == null || accountNumber == "" || accountNumber.Length != 10)
                return BadRequest("Account Number is required and length must be 10");

            
            var balance = await _accountService.GetBalanceAsync(accountNumber);
            if (balance == null) return NotFound();
            return Ok(balance);
        }

        [HttpGet("trnHist/{accountNumber}")]
        public async Task<IActionResult> GetTransactionHistory(string accountNumber)
        {
            if(accountNumber == null || accountNumber == "" || accountNumber.Length != 10)
                return BadRequest("Account Number is required and length must be 10");

            
            var transactionHistory = await _accountService.GetTransactionHistoryAsync(accountNumber);
            if (transactionHistory == null) return NotFound();
            return Ok(transactionHistory);
        }

        [HttpPut("{accountNumber}")]
        public async Task<IActionResult> UpdateAccount(string accountNumber, [FromBody] UpdateAccountDto updatedAccount)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _accountService.UpdateAccountAsync(accountNumber, updatedAccount);

            if (!success) return NotFound();

            return Ok(updatedAccount);
        }

        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> DeleteAccount(string accountNumber)
        {
            if(accountNumber == null || accountNumber == "" || accountNumber.Length != 10)
                return BadRequest("Account Number is required and length must be 10");

            var success = await _accountService.DeleteAccountAsync(accountNumber);
            if (!success) return NotFound();
            return Ok();
        }

    }
}