using AutoMapper;
using GameService.Context;
using GameService.Dtos;
using GameService.Entities;
using GameService.ReturnModels;
using Microsoft.EntityFrameworkCore;

namespace GameService.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMapper _mapper;
    private readonly GameDbContext _context;

    public CategoryRepository(IMapper mapper, GameDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }



    public async Task<Result<Category>> Create(CategoryCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        category.CreatedTime = DateTime.UtcNow;
        var created = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return new Result<Category>()
        {
            Data = created.Entity,
            Message = "Successfull",
            Success = true
        };
    }

    public async Task<Result<Category>> Update(CategoryUpdateDto dto)
    {
        var category = await _context.Categories.FindAsync(dto.Id);
        if (category is null)
        {
            return new Result<Category>()
            {
                Message = "Category Not Found",
                Success = false
            };
        }

        category.Name = dto.Name;
        category.Description = dto.Description;
        
        await _context.SaveChangesAsync();

        return new Result<Category>()
        {
            Data = category,
            Message = "Successfull",
            Success = true
        };
    }

    public async Task<Result<CategoryResponseDto>> GetById(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null)
        {
            return new Result<CategoryResponseDto>()
            {
                Message = "Category Not Found",
                Success = false
            };
        }

        var response = _mapper.Map<CategoryResponseDto>(category);

        return new Result<CategoryResponseDto>()
        {
            Data = response,
            Message = "Successfull",
            Success = true
        };
    }

    public async Task<Result<List<CategoryResponseDto>>> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();

        var response = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new Result<List<CategoryResponseDto>>()
        {
            Data = response,
            Success = true,
            Message = "Successfull"
        };
    }
}