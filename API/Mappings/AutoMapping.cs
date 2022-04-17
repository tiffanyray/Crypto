using System.Collections;
using System.Collections.Generic;
using API.RequestDtos;
using API.ResponseDtos;
using AutoMapper;
using Domain.Entities;

namespace API.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PortfolioRequest, Portfolio>();
            CreateMap<Portfolio, PortfolioResponse>();
            CreateMap<List<Portfolio>, List<PortfolioResponse>>();

            CreateMap<TransactionRequest, Transaction>();
            CreateMap<Transaction, TransactionResponse>();
            CreateMap<IEnumerable<Transaction>, List<TransactionResponse>>();

            CreateMap<CryptoRequest, Crypto>();
            CreateMap<Crypto, CryptoResponse>();
            CreateMap<IEnumerable<Crypto>, List<CryptoResponse>>();
        }
    }
}