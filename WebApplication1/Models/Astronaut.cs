namespace WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Astronaut
{
    public int Id { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }
        
    public DateTime BirthDate { get; set; }
        
    [MaxLength(100)]
    public string Nationality { get; set; }
        
    public ICollection<AstronautMission> AstronautMissions { get; set; }
}