using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BH.Assessment.Persistence;

public static class PersistenceServicesRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BhAssessmentContext>(opt =>
            opt.UseSqlite("Data Source=BHAssessment.db"));


        //services.AddDbContext<BhAssessmentContext>(options =>
        //    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BHAssessment;Trusted_Connection=True;"));


        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}