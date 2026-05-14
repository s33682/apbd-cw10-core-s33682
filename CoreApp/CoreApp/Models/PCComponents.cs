using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Models;

[PrimaryKey(nameof(PcId), nameof(ComponentCode))]
public class PCComponents
{
    public int PcId { get; set; }
    [MaxLength(10)]
    public string ComponentCode { get; set; } =  String.Empty;
    public int Amount { get; set; }
    [ForeignKey(nameof(PcId))]
    public PC Pc { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Components Components { get; set; } = null!;
}