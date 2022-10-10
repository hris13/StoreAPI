using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.Repo.Interfaces;
using store.Services.Interfaces;
using storeDTO.Account;

namespace store.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountDTO> CreateAccountAsync(AccountDTO request)
        {
            if (request != null)
            {
                Account newAccount = _mapper.Map<Account>(request);
                await _accountRepository.AddAccountAsync(newAccount);
                return request;
            }
            else return null;

        }
        public async Task<AccountDTO> GetAccountByIdAsync(int accountId)
        {
            Account account = await _accountRepository.GetAccountByIdAsync(accountId);
            AccountDTO acc = _mapper.Map<AccountDTO>(account);
            
                return acc;
            
        }
        public async Task UpdateAccountAsync(UpdateDTO acc)
        {
            Account account=_mapper.Map<Account>(acc);
             await _accountRepository.UpdateAccountAsync(account);
            
        }
        public async Task DeleteAccountAsync(int accountId)
        {
            await _accountRepository.DeleteAccountAsync(accountId);
           
        }
        public async Task<List<AccountDTO>> GetAllAsync()
        {
            List<Account> list=await _accountRepository.GetAllAccountsAsync();
            List<AccountDTO> newlist = _mapper.Map<List<AccountDTO>>(list);
            return newlist;
        }

       
    }
}