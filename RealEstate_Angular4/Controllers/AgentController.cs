using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate_Angular4.models;

namespace RealEstate_Angular4.Controllers
{
    [Produces("application/json")]
    [Route("api/Agent")]
    public class AgentController : Controller
    {
        private readonly realestateContext _context;

        public AgentController(realestateContext context)
        {
            _context = context;
        }

        // GET: api/Agents
        [HttpGet]
        public IEnumerable<Agent> GetAgent()
        {
            return _context.Agent;
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agent = await _context.Agent.SingleOrDefaultAsync(m => m.AgentId == id);

            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }

        // PUT: api/Agents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent([FromRoute] int id, [FromBody] Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agent.AgentId)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
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

        // POST: api/Agents
        [HttpPost]
        public async Task<IActionResult> PostAgent([FromBody] Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Agent.Add(agent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AgentExists(agent.AgentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAgent", new { id = agent.AgentId }, agent);
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agent = await _context.Agent.SingleOrDefaultAsync(m => m.AgentId == id);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agent.Remove(agent);
            await _context.SaveChangesAsync();

            return Ok(agent);
        }

        private bool AgentExists(int id)
        {
            return _context.Agent.Any(e => e.AgentId == id);
        }
    }
}