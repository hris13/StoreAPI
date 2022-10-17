using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Repo.Interfaces;
using store.Services.Interfaces;
using storeDTO.Account;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly StoreContext _ctx;

        public AccountsController(IAccountService _accountService, StoreContext ctx)
        {
            accountService = _accountService;
            _ctx = ctx;
        }

        // GET: api/Accounts
        [HttpGet("getall")]
        public async Task<ActionResult<List<AccountDTO>>> GetAccounts()
        {
            var list= await accountService.GetAllAsync();
            if (list == null)
                return NotFound("There are no records in the database yet");
            else return Ok(list);
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
        public async Task<IActionResult> UpdateAccount([FromRoute] int id, [FromBody] UpdateDTO account)
        {
            if (nullAccount(account))
            {
                return BadRequest("Account can not have null properties");
            }
            else {
                account.AccountId = id;
                await accountService.UpdateAccountAsync(account);
                return Ok("Account updated");
            }
        }

        private bool nullAccount(UpdateDTO account)
        {
            if ((account.AccountId == null) || (account.FirstName == null) || (account.LastName == null) || (account.UserName == null) || (account.Email == null))
                return true;
            else return false;
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccDTO account)
        {

            if (!checkExists(account))
            {
                await accountService.CreateAccountAsync(account);
                return Ok("Account Created");
            }
            else return BadRequest("User allready exists");
            
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound("Account with that id is not found");
            }
            await accountService.DeleteAccountAsync(id);

            return Ok("Succesfully deleted");
        }

        bool checkExists(AccDTO acc)
        {
            var a = _ctx.Accounts.Where(x => x.UserName == acc.UserName).FirstOrDefault();
            var b = _ctx.Accounts.Where(x => x.Email == acc.Email).FirstOrDefault();
            if (a == null && b == null) return false;
            else return true;
        }
    }
}
