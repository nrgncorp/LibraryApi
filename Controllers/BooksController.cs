using Microsoft.AspNetCore.Mvc;
using KutuphaneApi.Models;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> books = new()
    {
        new Book(1, "Tutunamayanlar", "Oğuz Atay"),
        new Book(2, "Kürk Mantolu Madonna", "Sabahattin Ali"),
        new Book(3, "İnce Memed", "Yaşar Kemal")
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
    public IActionResult Create(Book book)
    {
        var newId = books.Max(b => b.Id) + 1;
        var newBook = book with {Id = newId};

        books.Add(newBook);
        return CreatedAtAction(nameof(GetById), new {id = newBook.Id}, newBook);
    }
}