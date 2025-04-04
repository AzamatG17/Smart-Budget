using AutoMapper;
using SmartBudget.Api.Features.Commands.TransactionCommands;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Mappings;

public sealed class TransactionMapping : Profile
{
    public TransactionMapping()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(x => x.CategoryName, cfg => cfg.MapFrom(e => e.Category.Name))
            .ForMember(x => x.CategoryTransactionType, cfg => cfg.MapFrom(e => e.Category.TransactionType.ToString()));
        CreateMap<TransactionDto, Transaction>();

        CreateMap<CreateTransactionCommand, Transaction>();
        CreateMap<UpdateTransactionCommand, Transaction>();
    }
}
