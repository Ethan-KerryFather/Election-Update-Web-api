using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Context;

namespace WebApplication1.Controllers
{

    public class PostCandidateDataDTO
    {
        public double Candidate1 { get; set; }
        public double Candidate2 { get; set; }
    }
    [Route("/[controller]")]
    [ApiController]
    public class ElectionsController : ControllerBase
    {
        private readonly ElectionContext _context;

        public ElectionsController(ElectionContext context)
        {
            _context = context;
        }

        // GET: api/Elections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Election>>> GetElections()
        {
            return await _context.Elections.ToListAsync();
        }

        // GET: api/Elections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Election>> GetElection(int id)
        {
            var election = await _context.Elections.FindAsync(id);

            if (election == null)
            {
                return NotFound();
            }

            return election;
        }

   
        // POST: api/Elections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Election>> PostElection([FromBody] PostCandidateDataDTO postDTO)
        {
            var election = new Election
            {
                Condidate1 = postDTO.Candidate1,
                Candidate2 = postDTO.Candidate2,
            };

            _context.Elections.Add(election);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElection", new { id = election.UpdatedId }, election);
        }

       

        private bool ElectionExists(int id)
        {
            return _context.Elections.Any(e => e.UpdatedId == id);
        }
    }
}
