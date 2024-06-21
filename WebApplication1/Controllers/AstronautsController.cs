using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AstronautsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Astronaut>>> GetAstronauts(string sortOrder = "name")
        {
            IQueryable<Astronaut> astronauts = _context.Astronauts;

            switch (sortOrder.ToLower())
            {
                case "birthdate":
                    astronauts = astronauts.OrderBy(a => a.BirthDate);
                    break;
                case "nationality":
                    astronauts = astronauts.OrderBy(a => a.Nationality);
                    break;
                default:
                    astronauts = astronauts.OrderBy(a => a.FullName);
                    break;
            }

            return await astronauts.ToListAsync();
        }
    }
}