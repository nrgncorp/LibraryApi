using Microsoft.AspNetCore.Mvc;
using KutuphaneApi.Models;
using KutuphaneApi.Dtos;
using KutuphaneApi.Data;

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
    public IActionResult GetAll()
    {
        return Ok(_db.Books);
    } 

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _db.Books.FirstOrDefault(b => b.Id == id);
        if(book == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create(CreateBookRequest request)
    {
        var newBook = new Book {Title = request.Title, Author = request.Author };

        _db.Books.Add(newBook);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = newBook.Id}, newBook);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var found = _db.Books.FirstOrDefault(b => b.Id == id);
        if (found == null)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        _db.Books.Remove(found);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update(UpdateBookRequest request, int id)
    {
        var found = _db.Books.FirstOrDefault(b => b.Id == id);
        if (found == null)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        found.Title = request.Title;
        found.Author = request.Author;
        _db.SaveChanges();
        return NoContent();
    }
}