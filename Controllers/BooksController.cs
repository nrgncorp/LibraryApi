using Microsoft.AspNetCore.Mvc;
using KutuphaneApi.Models;
using KutuphaneApi.Dtos;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> books = new()
    {
        new Book { Id = 1, Title = "Tutunamayanlar", Author = "Oğuz Atay" },
        new Book { Id = 2, Title = "Kürk Mantolu Madonna", Author = "Sabahattin Ali" },
        new Book { Id = 3, Title = "İnce Memed", Author = "Yaşar Kemal" },
    };

    [HttpGet()]
    public IActionResult GetAll()
    {
        return Ok(books);
    } 

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if(book == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create(CreateBookRequest request)
    {
        var newId = books.Max(b => b.Id) + 1;
        var newBook = new Book { Id = newId, Title = request.Title, Author = request.Author };

        books.Add(newBook);
        return CreatedAtAction(nameof(GetById), new {id = newBook.Id}, newBook);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var found = books.FirstOrDefault(b => b.Id == id);
        if (found == null)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        books.Remove(found);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update(UpdateBookRequest request, int id)
    {
        var index = books.FindIndex(b => b.Id == id);
        if (index == -1)
        {
            return NotFound("Kayıt Bulunamadı...");
        }
        books[index] = new Book { Id = id, Title = request.Title, Author = request.Author };

        return NoContent();
    }
}