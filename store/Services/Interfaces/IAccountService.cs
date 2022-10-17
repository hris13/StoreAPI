using storeDTO.Account;
namespace store.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<AccountDTO> GetAccountByIdAsync(int accountId);
        public Task<AccDTO> CreateAccountAsync(AccDTO account);
        public Task UpdateAccountAsync(UpdateDTO account);
        public Task DeleteAccountAsync(int accountId);
        public Task<List<AccountDTO>> GetAllAsync();

    }
}
