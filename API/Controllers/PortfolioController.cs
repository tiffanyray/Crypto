using Application.Abstract;
using AutoMapper;

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
    }
}