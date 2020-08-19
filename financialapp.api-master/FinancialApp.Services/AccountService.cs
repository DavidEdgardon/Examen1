using FinancialApp.Core;
using FinancialApp.Core.Models;
using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ServiceResult<IEnumerable<AccountModel>> GetAccounts()
        {
            var result = this._accountRepository.All()
                 .Select(x => new AccountModel
                 {
                     Name = x.Name,
                     Amount = x.Amount,
                     Currency = x.Currency,
                     ConversionRate = x.ConversionRate
                 }).ToList();
            return ServiceResult<IEnumerable<AccountModel>>.SuccessResult(result);
        }

    }
}
