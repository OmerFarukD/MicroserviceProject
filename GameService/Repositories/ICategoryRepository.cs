using GameService.Dtos;
using GameService.Entities;
using GameService.ReturnModels;

namespace GameService.Repositories;

public interface ICategoryRepository
{
    Task<Result<Category>> Create(CategoryCreateDto dto);
    Task<Result<Category>> Update(CategoryUpdateDto dto);
    Task<Result<CategoryResponseDto>> GetById(Guid id);
    Task<Result<List<CategoryResponseDto>>> GetAll();
}