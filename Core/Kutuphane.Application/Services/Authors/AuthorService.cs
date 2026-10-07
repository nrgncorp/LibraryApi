using Kutuphane.Application.Repositories.Authors;
using Kutuphane.Application.Repositories;
using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Dtos.Authors;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IAuthorRepository repository, IUnitOfWork unitOfWork){
        _repository = repository;
        _unitOfWork = unitOfWork;
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
        _repository.Add(newAuthor);
        await _unitOfWork.SaveChangesAsync();
        return newAuthor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        _repository.Delete(found);
        await _unitOfWork.SaveChangesAsync();
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
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}