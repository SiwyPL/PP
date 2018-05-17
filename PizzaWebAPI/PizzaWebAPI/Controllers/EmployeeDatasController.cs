using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaWebAPI.Model;

namespace PizzaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/EmployeeDatas")]
    public class EmployeeDatasController : Controller
    {
        private readonly ModelContext _context;

        public EmployeeDatasController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDatas
        [HttpGet]
        public IEnumerable<EmployeeData> GetEmployeesData()
        {
            return _context.EmployeesData;
        }

        // GET: api/EmployeeDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeData = await _context.EmployeesData.SingleOrDefaultAsync(m => m.Id == id);

            if (employeeData == null)
            {
                return NotFound();
            }

            return Ok(employeeData);
        }

        // PUT: api/EmployeeDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeData([FromRoute] int id, [FromBody] EmployeeData employeeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeData.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDataExists(id))
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

        // POST: api/EmployeeDatas
        [HttpPost]
        public async Task<IActionResult> PostEmployeeData([FromBody] EmployeeData employeeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeesData.Add(employeeData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeData", new { id = employeeData.Id }, employeeData);
        }

        // DELETE: api/EmployeeDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeData = await _context.EmployeesData.SingleOrDefaultAsync(m => m.Id == id);
            if (employeeData == null)
            {
                return NotFound();
            }

            _context.EmployeesData.Remove(employeeData);
            await _context.SaveChangesAsync();

            return Ok(employeeData);
        }

        private bool EmployeeDataExists(int id)
        {
            return _context.EmployeesData.Any(e => e.Id == id);
        }
    }
}