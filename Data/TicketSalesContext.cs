using System.ComponentModel.DataAnnotations.Schema;
using iThome2024.ProcessService.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace iThome2024.ProcessService.Data;

public class TicketSalesContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<Seat> Seat { get; set; }
    public DbSet<Ticket> Ticket { get; set; }


    public TicketSalesContext(DbContextOptions<TicketSalesContext> options) : base(options)
    {
    }
}