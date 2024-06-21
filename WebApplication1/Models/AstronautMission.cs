namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class AstronautMission
{
    [Key, Column(Order = 0)]
    public int AstronautId { get; set; }
    public Astronaut Astronaut { get; set; }

    [Key, Column(Order = 1)]
    public int MissionId { get; set; }
    public Mission Mission { get; set; }
        
    [MaxLength(100)]
    public string Role { get; set; }
}