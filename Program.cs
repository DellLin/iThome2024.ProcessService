using iThome2024.ProcessService.Data;
using iThome2024.ProcessService.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

app.MapPost("/Test/SubEndpoint", (PubSubMessage context) =>
{
    string utf8String = Base64Converter.Base64ToUtf8(context.Message?.Data ?? "");
    app.Logger.LogInformation(utf8String);
    return Results.Ok();
})
.WithName("TestSubEndpoint")
.WithOpenApi();

app.Run();