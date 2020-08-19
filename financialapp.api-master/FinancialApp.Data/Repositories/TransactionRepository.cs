using FinancialApp.Core;
using FinancialApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Data.Repository
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly FinancialAppContext _financialAppContext;

        public TransactionRepository(FinancialAppContext financialAppContext)
        {
            _financialAppContext = financialAppContext;
        }

        public Transaction Add(Transaction entity)
        {
            _financialAppContext.Transaction.Add(entity);
            return entity;
        }

        public IQueryable<Transaction> All()
        {
            return _financialAppContext.Transaction;
        }

        public int SaveChanges()
        {
            return _financialAppContext.SaveChanges();
        }

        public Transaction Update(Transaction entity)
        {
            _financialAppContext.Transaction.Update(entity);
            return entity;
        }
    }
}
