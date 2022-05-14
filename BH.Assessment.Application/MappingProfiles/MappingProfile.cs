using AutoMapper;
using BH.Assessment.Application.Features.Accounts.Commands;
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Transaction 
        CreateMap<CreateAccountCommand, Transaction>()
            .ForMember(m => m.Amount
                , expression => expression.MapFrom(e => e.InitCredit));
    }
}