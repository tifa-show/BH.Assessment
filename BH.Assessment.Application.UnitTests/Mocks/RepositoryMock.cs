using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;
using Moq;

namespace BH.Assessment.Application.UnitTests.Mocks;

public class RepositoryMock
{
    public static Mock<ICustomerRepository> GetUserInformationRepository()
    {
        var customerGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

        var customers = new List<Customer>
        {
            new()
            {
                Id = customerGuid,
                Name = "Mustafa",
                Surname = "Wali",
                Balance = 5000.6,
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = "Test User",
                LastModifiedDate = DateTimeOffset.Now,
                LastModifyBy = "Test User"
            }
        };

        var mockCategoryRepository = new Mock<ICustomerRepository>();

        mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(customers);

        mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>())).ReturnsAsync(
            (Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });

        return mockCategoryRepository;
    }
}