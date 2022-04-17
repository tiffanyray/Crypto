using System.Collections.Generic;
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

        public async Task<ActionResult<TransactionResponse>> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<Transaction>, List<TransactionResponse>>(transactions);
            return Ok(mapped);
        }

        public async Task<ActionResult<TransactionResponse>> GetAllByUserId(string userId)
        {
            var transactions = await _transactionService.GetAllByUserIDAsync(userId);
            var mapped = _mapper.Map<IEnumerable<Transaction>, List<TransactionResponse>>(transactions);
            return Ok(mapped);
        }

        public async Task<IActionResult> GetOneById(int id)
        {
            var transaction = await _transactionService.GetOneAsync(id);
            if (!transaction.Success)
                return BadRequest(transaction.Message);

            var mapped = _mapper.Map<Transaction, TransactionResponse>(transaction.Resource);
            return Ok(mapped);
        }

        public async Task<IActionResult> CreateAsync(TransactionRequest transaction)
        {
            var mapRequest = _mapper.Map<TransactionRequest, Transaction>(transaction);
            var response = await _transactionService.AddAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Transaction, TransactionResponse>(response.Resource);
            return Ok(mapResponse);
        }

        public async Task<IActionResult> UpdateAsync(TransactionRequest transaction)
        {
            var mapRequest = _mapper.Map<TransactionRequest, Transaction>(transaction);
            var response = await _transactionService.UpdateAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Transaction, TransactionResponse>(response.Resource);
            return Ok(mapResponse);
        }

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