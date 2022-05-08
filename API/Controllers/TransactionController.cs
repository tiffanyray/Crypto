using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.RequestDtos;
using API.ResponseDtos;
using Application.Abstract;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(List<Transaction>), 200)]
        public async Task<ActionResult<Transaction>> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions.ToList());
        }
        
        [HttpGet]
        [Route("allbyuserid")]
        [ProducesResponseType(typeof(List<Transaction>), 200)]
        public async Task<ActionResult<Transaction>> GetAllByUserId(string userId)
        {
            var transactions = await _transactionService.GetAllByUserIDAsync(userId);
            return Ok(transactions.ToList());
        }

        [HttpGet]
        [Route("one")]
        [ProducesResponseType(typeof(TransactionResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetOneById(int id)
        {
            var transaction = await _transactionService.GetOneAsync(id);
            if (!transaction.Success)
                return BadRequest(transaction.Message);

            var mapped = _mapper.Map<Transaction, TransactionResponse>(transaction.Resource);
            return Ok(mapped);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(TransactionResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CreateAsync(TransactionRequest transaction)
        {
            var mapRequest = _mapper.Map<TransactionRequest, Transaction>(transaction);
            var response = await _transactionService.AddAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Transaction, TransactionResponse>(response.Resource);
            return Ok(mapResponse);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(TransactionResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> UpdateAsync(TransactionRequest transaction)
        {
            var mapRequest = _mapper.Map<TransactionRequest, Transaction>(transaction);
            var response = await _transactionService.UpdateAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Transaction, TransactionResponse>(response.Resource);
            return Ok(mapResponse);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(OkResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> DeleteAsync(TransactionRequest transaction)
        {
            var mapRequest = _mapper.Map<TransactionRequest, Transaction>(transaction);
            var response = await _transactionService.DeleteAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Transaction, TransactionResponse>(response.Resource);
            return Ok(mapResponse);
        }
    }
}