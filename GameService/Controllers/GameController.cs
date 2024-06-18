using GameService.Dtos.Games;
using GameService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController: ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create([FromForm] GameCreateDto dto)
    {
        var result = await _gameRepository.Create(dto);
        return Created("/", result);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var games = await _gameRepository.GetAll();
        return Ok(games);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var result = await _gameRepository.GetById(id);
        return Ok(result);
    }
    
    [HttpGet("getbycategory")]
    public async Task<IActionResult> GetAllByCategoryId(Guid id)
    {
        var response = await _gameRepository.GetAllByCategoryId(id);
        return Ok(response);
    }
    
}