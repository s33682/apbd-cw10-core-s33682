using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Models;

public class PC
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}