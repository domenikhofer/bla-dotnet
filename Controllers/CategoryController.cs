
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// dotnet aspnet-codegenerator controller -name CategoryController -async -api -m Category -dc ApplicationDbContext -outDir Controllers

namespace better_list_app_backend_dotnet.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            return await _context.Categories.Include(c => c.Children).Include(c => c.CategoryType).Where(c => c.ParentId == null).Select(c => new CategoryResponse(c)).ToListAsync();
        }

         // GET: api/Category/types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<CategoryTypeModel>>> GetCategoryTypes()
        {
            return await _context.CategoryTypes.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryWithEntriesResponse>> GetCategory(int id)
        {
            // TODO: Include entries only when flag is set in url
            var category = await _context.Categories.Include(c => c.Entries).Include(c => c.CategoryType).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return new CategoryWithEntriesResponse(category);
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromForm] CategoryCreateRequest category)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }
           
            var updatedCategory = new CategoryModel
            {
                Id = id,
                Name = category.Name,
                Emoji = category.Emoji,
                ParentId = category.ParentId,
                CategoryTypeId = category.CategoryTypeId
            }; // TODO: write mapper?

            _context.Entry(categoryToUpdate).CurrentValues.SetValues(updatedCategory);

            _context.Entry(categoryToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> PostCategory([FromForm] CategoryCreateRequest category)
        {

            var _category = new CategoryModel
            {
                Name = category.Name,
                Emoji = category.Emoji,
                ParentId = category.ParentId,
                CategoryType = _context.CategoryTypes.Find(category.CategoryTypeId)
            };

            if (ModelState.IsValid)
            {
                _context.Categories.Add(_category);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategory", new { id = _category.Id }, _category);
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
