using Microsoft.EntityFrameworkCore;

namespace iThome2024.ProcessService.Data;

public class TicketSalesContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<Seat> Seat { get; set; }


    public TicketSalesContext(DbContextOptions<TicketSalesContext> options) : base(options)
    {
    }
}
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮新增 'required' 修飾元，或將欄位宣告為可以為 Null。

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public DateTime CreateTime { get; set; }
}
public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime StartSalesDate { get; set; }
    public DateTime EndSalesDate { get; set; }
    public string Description { get; set; }
    public string Remark { get; set; }
    public List<Seat> Seats { get; } = new();

}
public class Seat
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Area { get; set; }
    public string Name { get; set; }
    public int Status { get; set; }
    public Event Event { get; set; }
}
#pragma warning restore CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮新增 'required' 修飾元，或將欄位宣告為可以為 Null。
