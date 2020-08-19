using FinancialApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Models;
using FinancialApp.Data.Entities;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace FinancialApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Account> _accountRepository;

        public TransactionService(IRepository<Transaction> transactionRepository, IRepository<Account> accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;

        }

        public ServiceResult<TransactionModel> AddTransaction(TransactionModel transaction)
        {
            var entity = new Transaction
            {
                Description = transaction.Description,
                Amount = transaction.Amount,
                AccountId = transaction.AccountId,
                TransactionDate = transaction.TransactionDate
            };

            var result = _transactionRepository.Add(entity);
            _transactionRepository.SaveChanges();
            transaction.Id = result.Id;
            return ServiceResult<TransactionModel>.SuccessResult(transaction);
        }

        public ServiceResult<IEnumerable<TransactionModel>> GetTransactions()
        {
            var result = this._transactionRepository.All()
                .Select(x => new TransactionModel
                {
                    Description = x.Description,
                    Amount = x.Amount,
                    AccountId = x.AccountId,
                    TransactionDate = x.TransactionDate
                }).Take(5);
            return ServiceResult<IEnumerable<TransactionModel>>.SuccessResult(result);
        }

        public ServiceResult<SummaryModel> GetSummary(long id)
        {
            double total = 0;
            
            var data = this._transactionRepository.All().Where(x => x.Id == id)
                     .Select(x => new TransactionModel
                     {
                         Description = x.Description,
                         Amount = x.Amount,
                         AccountId = x.AccountId,
                         TransactionDate = x.TransactionDate,
                     }).ToList();

            double income = (from x in data where x.Amount >= 0 select x.Amount).Sum();
            double expense = (from x in data where x.Amount < 0 select x.Amount).Sum();

            var data1 = this._accountRepository.All()
                 .Select(y => new AccountModel
                 {
                   Id = y.Id,
                   ConversionRate = y.ConversionRate
                   
                 }).ToList();

            //Solo encuenta uno, ya el id es unico
            double conversionRate = (from y in data1 where y.Id == id select y.ConversionRate).Sum();

            income = (income * conversionRate);
            expense = (expense * conversionRate);

            total = (income + expense);

            var result = new SummaryModel
            {
                Income = income,
                Expenses = expense,
                Total = total
            };
            return ServiceResult<SummaryModel>.SuccessResult(result);


        }
    }
}
