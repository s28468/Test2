namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

public class Organization
{
    public int Id { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
        
    [MaxLength(100)]
    public string Country { get; set; }
        
    public ICollection<Mission> Missions { get; set; }
}