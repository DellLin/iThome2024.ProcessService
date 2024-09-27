using System.Text.Json;
using iThome2024.ProcessService.Data;
using iThome2024.ProcessService.Data.Model;
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

app.MapPost("/Test/SubEndpoint", async (PubSubMessage pubSubMessage,
        [FromServices] TicketSalesContext context) =>
{
    string utf8String = Base64Converter.Base64ToUtf8(pubSubMessage.Message?.Data ?? "");
    var ticketViewModel = JsonSerializer.Deserialize<TicketViewModel>(utf8String);
    if (ticketViewModel == null)
    {
        return Results.BadRequest();
    }
    await context.Ticket.AddAsync(new Ticket
    {
        SeatId = ticketViewModel.SeatId,
        UserId = context.User.First().Id,
        CreateTime = ticketViewModel.CreateTime
    });
    await context.SaveChangesAsync();
    return Results.Ok();
})
.WithName("TestSubEndpoint")
.WithOpenApi();

app.Run();