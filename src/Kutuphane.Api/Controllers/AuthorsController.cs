using Microsoft.AspNetCore.Mvc;
using Kutuphane.Application.Dtos;
using Kutuphane.Application.Interfaces;

[ApiController]
[Route("authors")]

public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
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
        var author = await _service.GetByIdAsync(id);
        if(author == null)
        {
            return NotFound("Kayıt Bulunamadı..");
        }
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorRequest request)
    {
        var newAuthor = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new {id = newAuthor.Id }, newAuthor);
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
    public async Task<IActionResult> Update(UpdateAuthorRequest request, int id)
    {
        var result = await _service.UpdateAsync(request, id);
        if (!result)
        {
            return NotFound("Kayıt Güncellenemedi..");
        }
        return NoContent();
    }
}