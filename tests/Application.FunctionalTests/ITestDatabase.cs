using System.Data.Common;

namespace BonefireECommerce.Application.FunctionalTests;
public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
