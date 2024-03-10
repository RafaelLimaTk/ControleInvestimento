using AutoMapper;
using ControleInvestimento.AppMvc.ViewModels;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Portifolio;
using System.Transactions;

namespace ControleInvestimento.AppMvc.Mappings;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Asset, AssetViewModel>();
        CreateMap<Transaction, TransactionViewModel>();
        CreateMap<InvestmentStatics, InvestmentStaticsViewModel>();
        CreateMap<Portfolio, PortfolioViewModel>();
    }
}
