using FinancialApp.Core;
using FinancialApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Services
{
    public interface IAccountService
    {
        ServiceResult<IEnumerable<AccountModel>> GetAccounts();

    }
}
