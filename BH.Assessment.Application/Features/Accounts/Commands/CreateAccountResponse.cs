using BH.Assessment.Application.Response;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountResponse : BaseResponse
{
    public CreateAccountDto Account { get; set; }
}