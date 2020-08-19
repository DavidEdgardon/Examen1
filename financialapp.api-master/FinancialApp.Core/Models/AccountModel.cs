using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Core.Models
{
    public class AccountModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public double ConversionRate { get; set; }
    }
}
