using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.VectorStinger_Api_Service>("vectorstinger-apiservice");

//builder.AddProject<Projects.VectorStinger_Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithReference(apiService)
//    .WaitFor(apiService);

builder.AddProject<Projects.VectorStinger_Api_Security>("vectorstinger-security-apiservice");

builder.Build().Run();
