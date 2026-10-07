using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Dtos.Books;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;
    public BooksController(IBookService service)
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
        var book = await _service.GetByIdAsync(id);
        if(book == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        var newBook = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
        {
            return NotFound("Kayıt Silinemedi..");
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateBookRequest request, int id)
    {
        var result = await _service.UpdateAsync(request, id);
        if (!result)
        {
            return NotFound("Kayıt Güncellenemedi..");
        }
        return NoContent();
    }
}