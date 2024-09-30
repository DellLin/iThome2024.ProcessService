using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace iThome2024.ProcessService.Data.Model;

[Index(nameof(SeatId), IsUnique = true)]
public class Ticket
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int SeatId { get; set; }
    public int UserId { get; set; }
    [Column(TypeName = "timestamp")]
    public DateTime CreateTime { get; set; }
    public Seat Seat { get; set; }
    public User User { get; set; }
}
