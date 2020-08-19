using FinancialApp.Core;
using FinancialApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


namespace FinancialApp.Services
{
    public interface ITransactionService
    {
        ServiceResult<TransactionModel> AddTransaction(TransactionModel trasanction);

        ServiceResult<IEnumerable<TransactionModel>> GetTransactions();

        ServiceResult<SummaryModel> GetSummary(long id);


    }
}
