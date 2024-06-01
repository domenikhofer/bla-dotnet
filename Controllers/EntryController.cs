using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using better_list_app_backend_dotnet.Data;
using better_list_app_backend_dotnet.Models;

namespace better_list_app_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Entry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryModel>>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        // GET: api/Entry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryModel>> GetEntryModel(int id)
        {
            var entryModel = await _context.Entries.FindAsync(id);

            if (entryModel == null)
            {
                return NotFound();
            }

            return entryModel;
        }

         // GET: api/Entry/5
        [HttpGet("search/{categoryId}/{searchText}")]
        public async Task<ActionResult<IEnumerable<EntryModel>>> GetSimilarEntries(int categoryId, string searchText)
        {
            var entryModel = await _context.Entries.Where(e => e.CategoryId == categoryId && e.Value.Contains(searchText)).ToListAsync();

            if (entryModel == null)
            {
                return NotFound();
            }

            return entryModel;
        }

        // PUT: api/Entry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntryModel(int id, EntryModel entryModel)
        {
            if (id != entryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(entryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryModelExists(id))
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

        // POST: api/Entry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostEntryModel([FromBody] List<EntriesCreateModel> entries)
        {

            _context.Entries.RemoveRange(_context.Entries.Where(e => e.CategoryId == entries.First().CategoryId));
            await _context.SaveChangesAsync();

            entries.ForEach(entry =>
            {
                _context.Entries.Add(new EntryModel
                {
                    Value = entry.Value,
                    Url = entry.Url,
                    Image = entry.Image,
                    IsDone = entry.IsDone,
                    CategoryId = entry.CategoryId
                });
            });

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Entry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntryModel(int id)
        {
            var entryModel = await _context.Entries.FindAsync(id);
            if (entryModel == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntryModelExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
