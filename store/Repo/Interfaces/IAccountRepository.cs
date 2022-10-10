using store.Models;

namespace store.Repo.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> AddAccountAsync(Account account);
        public Task<Account> UpdateAccountAsync(Account account);
        public Task<Account> GetAccountByIdAsync(int id);
        public Task<List<Account>> GetAllAccountsAsync();
        public Task<Account> DeleteAccountAsync(int id);
    }
}
