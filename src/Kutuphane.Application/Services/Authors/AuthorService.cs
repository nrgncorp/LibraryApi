using Kutuphane.Application.Dtos.Authors;
using Kutuphane.Application.Interfaces.Authors;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository){
        _repository = repository;
    }

    public async Task <List<Author>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Author> CreateAsync(CreateAuthorRequest request)
    {
        var newAuthor = new Author {
        Name = request.Name,
        Surname = request.Surname,
        Country = request.Country,
        Biography = request.Biography,
        BirthDate = request.BirthDate,
        DeathDate = request.DeathDate,
        ImageUrl = request.ImageUrl
        };
        await _repository.AddAsync(newAuthor);
        return newAuthor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        await _repository.DeleteAsync(found);
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateAuthorRequest request, int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        found.Name = request.Name;
        found.Surname = request.Surname;
        found.Country = request.Country;
        found.Biography = request.Biography;
        found.BirthDate = request.BirthDate;
        found.DeathDate = request.DeathDate;
        found.ImageUrl = request.ImageUrl;
        found.UpdatedAt = DateTime.UtcNow;
        found.IsActive = request.IsActive!.Value;
        await _repository.SaveChangesAsync();
        return true;
    }
}