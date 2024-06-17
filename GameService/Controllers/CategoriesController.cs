using GameService.Dtos;
using GameService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _categoryRepository.GetAll();
        return Ok(response);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CategoryCreateDto dto)
    {
        var response = await _categoryRepository.Create(dto);
        return Created("/", response);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var response = await _categoryRepository.GetById(id);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] CategoryUpdateDto dto)
    {
        var response = await _categoryRepository.Update(dto);
        return Ok(response);
    }
}