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
    public class PortfolioController : BaseController
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;
        public PortfolioController(IPortfolioService portfolioService, IMapper mapper) : base ()
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(List<PortfolioResponse>), 200)]
        public async Task<ActionResult<List<PortfolioResponse>>> GetAllByUserId(string userId)
        {
            var portfolios = await _portfolioService.GetAllAsync();
            var mappedPortfolios = _mapper.Map<IEnumerable<Portfolio>, List<PortfolioResponse>>(portfolios);

            return mappedPortfolios;
        }

        [HttpGet]
        [Route("one")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<PortfolioResponse>> GetOne(int portfolioId)
        {
            var result = await _portfolioService.GetOneAsync(portfolioId);

            if (!result.Success)
                return BadRequest(new ErrorResponse(result.Message));

            var response = _mapper.Map<Portfolio, PortfolioResponse>(result.Resource);
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PostAsync([FromBody] PortfolioRequest portfolioR)
        {
            var portfolio = _mapper.Map<PortfolioRequest, Portfolio>(portfolioR);

            var result = await _portfolioService.SaveAsync(portfolio);
            if (!result.Success)
                return BadRequest(result.Message);

            var response = _mapper.Map<Portfolio, PortfolioResponse>(result.Resource);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PutAsync(PortfolioRequest portfolioR)
        {
            var portfolio = _mapper.Map<PortfolioRequest, Portfolio>(portfolioR);

            var result = await _portfolioService.UpdateAsync(portfolio);
            if (!result.Success)
                return BadRequest(result.Message);

            var response = _mapper.Map<Portfolio, PortfolioResponse>(result.Resource);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(OkResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _portfolioService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(new ErrorResponse(result.Message));

            return Ok();
        }
    }
}