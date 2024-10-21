var builder = DistributedApplication.CreateBuilder(args);

builder.AddPostgres("postgres").WithPgAdmin().AddDatabase("cms");

builder.AddProject<Projects.Northwind_WebApi>("api");

builder.Build().Run();
