using Microsoft.AspNetCore.Mvc;
using KutuphaneApi.Models;
using KutuphaneApi.Dtos;
using KutuphaneApi.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _db;
    public BooksController(LibraryDbContext db)
    {
        _db = db;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _db.Books.ToListAsync());
    } 

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if(book == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        var newBook = new Book {Title = request.Title, Author = request.Author };

        _db.Books.Add(newBook);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = newBook.Id}, newBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var found = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (found == null)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        _db.Books.Remove(found);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateBookRequest request, int id)
    {
        var found = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (found == null)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        found.Title = request.Title;
        found.Author = request.Author;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}