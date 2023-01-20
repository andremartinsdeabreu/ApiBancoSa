using AutoMapper;
using BancoSa.Models;
using Dominio.Models;

namespace BancoSa.Profiles
{
    public class CreditoProfile : Profile
    {
        public CreditoProfile()
        {
            CreateMap<RetornoStatus, CreditoResponse>();
            CreateMap<CreditoResponse, RetornoStatus>();
        }
    }
}
