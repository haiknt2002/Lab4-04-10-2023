using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab4_04_10_2023.Data;
using Lab4_04_10_2023.Models;

namespace Lab4_04_10_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerApiController : ControllerBase
    {
        private readonly SchoolContext _context;

        public LearnerApiController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/LearnerApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Learner>>> GetLearners()
        {
          if (_context.Learners == null)
          {
              return NotFound();
          }
            return await _context.Learners.ToListAsync();
        }

        // GET: api/LearnerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Learner>> GetLearner(int id)
        {
          if (_context.Learners == null)
          {
              return NotFound();
          }
            var learner = await _context.Learners.FindAsync(id);

            if (learner == null)
            {
                return NotFound();
            }

            return learner;
        }

        // PUT: api/LearnerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearner(int id, Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return BadRequest();
            }

            _context.Entry(learner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LearnerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Learner>> PostLearner(Learner learner)
        {
          if (_context.Learners == null)
          {
              return Problem("Entity set 'SchoolContext.Learners'  is null.");
          }
            _context.Learners.Add(learner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLearner", new { id = learner.LearnerID }, learner);
        }

        // DELETE: api/LearnerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearner(int id)
        {
            if (_context.Learners == null)
            {
                return NotFound();
            }
            var learner = await _context.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }

            _context.Learners.Remove(learner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearnerExists(int id)
        {
            return (_context.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }
    }
}
