using Google.Cloud.PubSub.V1;
using iThome2024.ProcessService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicketSalesContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TicketSalesContext"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Test/DbConnection", (TicketSalesContext context) =>
{
    return context.Database.CanConnect();
})
.WithName("TestDbConnection")
.WithOpenApi();

app.MapPost("/Test/SubEndpoint", (PubsubMessage context) =>
{
    app.Logger.LogInformation(context.Data.ToStringUtf8());
    return Results.Ok();
})
.WithName("TestSubEndpoint")
.WithOpenApi();

app.Run();