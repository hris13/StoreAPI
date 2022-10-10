using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Services.Interfaces;
using storeDTO.Account;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        // GET: api/Accounts
        [HttpGet("getall")]
        public async Task<ActionResult<List<AccountDTO>>> GetAccounts()
        {
            return await accountService.GetAllAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            else return account;
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute]int id,[FromBody]UpdateDTO account)
        {
            account.AccountId = id;
            await accountService.UpdateAccountAsync(account);
            return Ok();
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountDTO account)
        {
            await accountService.CreateAccountAsync(account);
            return Ok();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await accountService.DeleteAccountAsync(id);

            return Ok();
        }

      
    }
}
