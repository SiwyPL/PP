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
    [Route("api/AccountRoles")]
    public class AccountRolesController : Controller
    {
        private readonly ModelContext _context;

        public AccountRolesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/AccountRoles
        [HttpGet]
        public IEnumerable<AccountRole> GetAccountsRoles()
        {
            return _context.AccountsRoles;
        }

        // GET: api/AccountRoles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRole = await _context.AccountsRoles.SingleOrDefaultAsync(m => m.Id == id);

            if (accountRole == null)
            {
                return NotFound();
            }

            return Ok(accountRole);
        }

        // PUT: api/AccountRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountRole([FromRoute] int id, [FromBody] AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountRoleExists(id))
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

        // POST: api/AccountRoles
        [HttpPost]
        public async Task<IActionResult> PostAccountRole([FromBody] AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountsRoles.Add(accountRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountRole", new { id = accountRole.Id }, accountRole);
        }

        // DELETE: api/AccountRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRole = await _context.AccountsRoles.SingleOrDefaultAsync(m => m.Id == id);
            if (accountRole == null)
            {
                return NotFound();
            }

            _context.AccountsRoles.Remove(accountRole);
            await _context.SaveChangesAsync();

            return Ok(accountRole);
        }

        private bool AccountRoleExists(int id)
        {
            return _context.AccountsRoles.Any(e => e.Id == id);
        }
    }
}