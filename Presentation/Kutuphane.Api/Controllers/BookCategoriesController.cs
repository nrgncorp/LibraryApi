using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Dtos.BookCategory;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("bookCategories")]
public class BookCategoriesController : ControllerBase
{
    private readonly IBookCategoryService _service;
    public BookCategoriesController(IBookCategoryService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    } 

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var bookCategory = await _service.GetByIdAsync(id);
        if(bookCategory == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(bookCategory);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCategoryRequest request)
    {
        var newBookCategory = await _service.CreateAsync(request);
        if(newBookCategory == null)
        {
            return BadRequest("Kitap Kategorisi Bulunamadı..");
        }
        return CreatedAtAction(nameof(GetById), new { id = newBookCategory.Id }, newBookCategory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
        {
            return NotFound("Kayıt Silinemedi: Kategori bulunamadı veya Kategoriye tanımlı kitap(lar) var.");
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateBookCategoryRequest request, int id)
    {
        var result = await _service.UpdateAsync(request, id);
        if (!result)
        {
            return NotFound("Kayıt Güncellenemedi..");
        }
        return NoContent();
    }
}