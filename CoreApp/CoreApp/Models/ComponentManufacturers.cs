using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models;

public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(300)]
    public string FullName { get; set; }
    public DateOnly FoundationDate { get; set; }
    public ICollection<Components> Components { get; set; } = [];
}