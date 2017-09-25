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
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private readonly realestateContext _context;

        public CompanyController(realestateContext context)
        {
            _context = context;
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> GetCompany()
        {
            return _context.Company;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.Company.SingleOrDefaultAsync(m => m.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] int id, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Company
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Company.Add(company);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyExists(company.CompanyId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.Company.SingleOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return Ok(company);
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyId == id);
        }
    }
}