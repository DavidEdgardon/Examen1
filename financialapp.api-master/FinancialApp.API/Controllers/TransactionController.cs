using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Core;
using FinancialApp.Core.Models;
using FinancialApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Post(TransactionModel transaction)
        {
            var transactionResult = _transactionService.AddTransaction(transaction);
            if (transactionResult.ResponseCode != ResponseCode.Success)
                return BadRequest(transactionResult.Error);
            return Ok(transactionResult.Result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var transactionResult = _transactionService.GetTransactions();
            if (transactionResult.ResponseCode != ResponseCode.Success)
                return BadRequest(transactionResult.Error);
            return Ok(transactionResult.Result);
        }

        [HttpGet("{id}/summary")]
        public IActionResult GetSummary(long id)
        {
            var summaryResult = _transactionService.GetSummary(id);
            if (summaryResult.ResponseCode != ResponseCode.Success)
                return BadRequest(summaryResult.Error);
            return Ok(summaryResult.Result);
        }

    }
}
