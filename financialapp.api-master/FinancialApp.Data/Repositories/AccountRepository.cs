using FinancialApp.Core;
using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Data.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly FinancialAppContext _financialAppContext;
        public AccountRepository(FinancialAppContext financialAppContext)
        {
            _financialAppContext = financialAppContext;
        }

        public Account Add(Account entity)
        {
            _financialAppContext.Account.Add(entity);
            return entity;
        }

        public IQueryable<Account> All()
        {
           return _financialAppContext.Account;
        }

        public int SaveChanges()
        {
            return _financialAppContext.SaveChanges();
        }

        public Account Update(Account entity)
        {
            _financialAppContext.Account.Update(entity);
            return entity;
        }
    }
}
