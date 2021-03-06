using AutoMapper;
using BH.Assessment.Application.Features.Accounts.Commands;
using BH.Assessment.Application.Features.Customers.Commands;
using BH.Assessment.Application.Features.Customers.Queries;
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAccountCommand, Transaction>()
            .ForMember(m => m.Amount
                , expression => expression.MapFrom(e => e.InitCredit));

        CreateMap<Customer, UserInformationVm>()
            .ForMember(destinationMember => destinationMember.CustomerId,
                expression => expression.MapFrom(sourceMember => sourceMember.Id))
            .ForMember(s => s.Transactions,
                c => c.MapFrom(m => m.Account.Transactions));

        CreateMap<Transaction, UserInformationTransactionDto>()
            .ForMember(dest => dest.TransactionId,
                expression => expression.MapFrom(src => src.Id));

        CreateMap<Account, CreateAccountDto>()
            .ForMember(dest => dest.AccountId, expression => expression.MapFrom(src => src.Id));

        CreateMap<CreateCustomerCommand, Customer>();
    }
}