using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models;

public class ComponentTypes
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    public ICollection<Components> Components { get; set; } = [];
}