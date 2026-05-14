using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Models;

public class Components
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturers ComponentManufacturers { get; set; } = null!;
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentTypes ComponentTypes {get; set; } = null!;
}