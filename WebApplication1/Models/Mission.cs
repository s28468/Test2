namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Mission
{
    public int Id { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
        
    public DateTime? LaunchDate { get; set; }
        
    [ForeignKey("Organization")]
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
        
    public ICollection<AstronautMission> AstronautMissions { get; set; }
}