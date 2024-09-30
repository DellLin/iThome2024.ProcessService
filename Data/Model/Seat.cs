using System.ComponentModel.DataAnnotations.Schema;

namespace iThome2024.ProcessService.Data.Model;

public class Seat
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int EventId { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string? Area { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
    public int Status { get; set; }
    public Event Event { get; set; }
}
