using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using server.Models;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ServerDbContext _dbContext;
    public CategoryController(ServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var Categories = await _dbContext.Categories.OrderBy(c => c.CategoryID).ToListAsync();
        return Ok(Categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "Invalid category ID provided." });
        }

        var Category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
        if (Category == null)
        {
            return NotFound();
        }
        return Ok(Category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category newCategory)
    {
        if (string.IsNullOrWhiteSpace(newCategory.CategoryName))
        {
            return BadRequest(new { message = "Category name is required." });
        }

        var checkCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == newCategory.CategoryID);
        if (checkCategory != null)
        {
            return BadRequest(new { message = "The category already exists. Please try again!" });
        }

        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories ON;");
            _dbContext.Categories.Add(newCategory); // Assume CategoryID is auto-incremented
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories OFF;");
            await transaction.CommitAsync();
        }
        
        return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.CategoryID }, newCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category updatedCategory)
    {
        if (id != updatedCategory.CategoryID)
        {
            return BadRequest(new { message = "Mismatched category ID." });
        }

        if (string.IsNullOrWhiteSpace(updatedCategory.CategoryName))
        {
            return BadRequest(new { message = "Category name is required." });
        }

        var Category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
        if (Category == null)
        {
            return NotFound();
        }

        Category.CategoryName = updatedCategory.CategoryName;
        Category.Description = updatedCategory.Description;
        await _dbContext.SaveChangesAsync();
        return Ok(Category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "Invalid category ID provided." });
        }

        var Category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
        if (Category == null)
        {
            return NotFound();
        }

        _dbContext.Categories.Remove(Category);
        await _dbContext.SaveChangesAsync();
        return Ok(new { message = "Category deleted successfully." });
    }
}
