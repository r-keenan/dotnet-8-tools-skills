using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.EntityModels;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddNorthwindContext(this IServiceCollection services,
        string? connectionString = null)
    {
        if (connectionString == null)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            string userId = configuration["DbInfo:UserId"] ?? "sa";
            string password = configuration["DbInfo:Password"] ?? "s3cret-Ninja";

            SqlConnectionStringBuilder builder = new();

            builder.DataSource = ".";
            builder.InitialCatalog = "Northwind";
            builder.UserID = userId;
            builder.Password = password;
            builder.DataSource = "tcp:127.0.0.1,1433";
            builder.ConnectTimeout = 3;
            builder.TrustServerCertificate = true;

            connectionString = builder.ConnectionString;
        }

        services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(connectionString);

                // Log to console when executing EF Core commands
                options.LogTo(Console.WriteLine,
                    new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
            },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);

          return services;
    }
}