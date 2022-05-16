using AutoMapper;
using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Application.Features.Customers.Queries;
using BH.Assessment.Application.MappingProfiles;
using BH.Assessment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace BH.Assessment.Application.UnitTests.Categories.Queries;

public class GetUserInformationQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICustomerRepository> _mockUserInformationRepository;

    public GetUserInformationQueryHandlerTests()
    {
        _mockUserInformationRepository = RepositoryMock.GetUserInformationRepository();

        var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetUserInformationQueryHandler(_mockUserInformationRepository.Object, _mapper);
        var result = await handler.Handle(new GetUserInformationQuery(), CancellationToken.None);

        result.ShouldBeOfType<UserInformationVm>();
        result.ShouldNotBeNull();
    }
}