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
    public class CryptoController : BaseController
    {
        private readonly ICryptoService _cryptoService;
        private readonly IMapper _mapper;

        public CryptoController(ICryptoService cryptoService, IMapper mapper)
        {
            _cryptoService = cryptoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(List<CryptoResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var cryptos = await _cryptoService.GetAll();
            return Ok(cryptos);
        }

        [HttpGet]
        [Route("one")]
        [ProducesResponseType(typeof(CryptoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetById(int id)
        {
            var crypto = await _cryptoService.GetById(id);
            if (!crypto.Success)
                return BadRequest(crypto.Message);

            var map = _mapper.Map<Crypto, CryptoResponse>(crypto.Resource);
            return Ok(map);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CryptoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Create(CryptoRequest crypto)
        {
            var mapRequest = _mapper.Map<CryptoRequest, Crypto>(crypto);
            var response = await _cryptoService.CreateAsync(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Crypto, CryptoResponse>(response.Resource);
            return Ok(mapResponse);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(CryptoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Update(CryptoRequest crypto)
        {
            var mapRequest = _mapper.Map<CryptoRequest, Crypto>(crypto);
            var response = await _cryptoService.Update(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Crypto, CryptoResponse>(response.Resource);
            return Ok(mapResponse);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(OkResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete(CryptoRequest crypto)
        {
            var mapRequest = _mapper.Map<CryptoRequest, Crypto>(crypto);
            var response = await _cryptoService.Delete(mapRequest);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<Crypto, CryptoResponse>(response.Resource);
            return Ok(mapResponse);
        }
    }
}