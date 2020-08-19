using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Core.Models
{
    public class TransactionModel
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public string Account { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
