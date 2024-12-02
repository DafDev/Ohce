using Daf.Oche.Api.Endpoints;
using Daf.Oche.Api.IoC;
using Daf.Oche.Domain.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddDomain()
    .AddDependencies()
    .AddEndpointDefinitions(typeof(IDefineEndpoints))
    .AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.Run();