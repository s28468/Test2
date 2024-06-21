using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Mission>> CreateMission(CreateMissionDto createMissionDto)
        {
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Name == createMissionDto.OrganizationName);

            if (organization == null)
            {
                return BadRequest("Organization not found");
            }

            var mission = new Mission
            {
                Name = createMissionDto.Name,
                LaunchDate = createMissionDto.LaunchDate,
                OrganizationId = organization.Id
            };

            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMissionById), new { id = mission.Id }, mission);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissions(string sortOrder = "name")
        {
            IQueryable<Mission> missions = _context.Missions.Include(m => m.Organization);

            switch (sortOrder.ToLower())
            {
                case "launchdate":
                    missions = missions.OrderBy(m => m.LaunchDate);
                    break;
                default:
                    missions = missions.OrderBy(m => m.Name);
                    break;
            }

            return await missions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMissionById(int id)
        {
            var mission = await _context.Missions.Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        [HttpPost("astronaut")]
        public async Task<ActionResult> AssignAstronautToMission(AssignAstronautDto assignAstronautDto)
        {
            var mission = await _context.Missions.FindAsync(assignAstronautDto.MissionId);
            if (mission == null)
            {
                return NotFound("Mission not found");
            }

            var astronaut = await _context.Astronauts.FindAsync(assignAstronautDto.AstronautId);
            if (astronaut == null)
            {
                return NotFound("Astronaut not found");
            }

            var astronautMission = new AstronautMission
            {
                AstronautId = assignAstronautDto.AstronautId,
                MissionId = assignAstronautDto.MissionId,
            };

            _context.AstronautMissions.Add(astronautMission);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
