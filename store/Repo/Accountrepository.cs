using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Repo.Interfaces;

namespace store.Repo
{
    public class AccountRepository:IAccountRepository
    {
        private readonly StoreContext _ctx;
        public AccountRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Account>AddAccountAsync(Account account)
        {
            _ctx.Accounts.Add(account);
            await _ctx.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            _ctx.Accounts.Update(account);
            await _ctx.SaveChangesAsync();
            return account;
        }
    
        public async Task<Account> GetAccountByIdAsync(int id)
        {
           var account=await _ctx.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
            return account;
        }
        public async Task<Account> DeleteAccountAsync(int id)
        {
            var account = await _ctx.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
            if (account == null)
                return null;
            _ctx.Accounts.Remove(account);
            await _ctx.SaveChangesAsync();
            return account;
        }

  
        public async Task<List<Account>>GetAllAccountsAsync()
        {
            return await _ctx.Accounts.ToListAsync();
        }
    }
}
