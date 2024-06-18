using AutoMapper;
using GameService.Context;
using GameService.Dtos.Games;
using GameService.Entities;
using GameService.ReturnModels;
using GameService.Services;
using Microsoft.EntityFrameworkCore;

namespace GameService.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMapper _mapper;
    private readonly GameDbContext _context;
    private readonly IFileService _fileService;

    public GameRepository(IMapper mapper, GameDbContext context, IFileService fileService)
    {
        _mapper = mapper;
        _context = context;
        _fileService = fileService;
    }

    public async Task<Result<Game>> Create(GameCreateDto dto)
    {
        if (dto.File.Length>0)
        {
            string videoUrl = await _fileService.UploadVideo(dto.File);
            var game = _mapper.Map<Game>(dto);
            game.VideoUrl = videoUrl;
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return new Result<Game>()
            {
                Data = game,
                Success = true,
                Message = "Successfull"
            };
        }

        return new()
        {
            Message = "Failed",
            Success = false
        };
    }

    public async Task<Result<Game>> Update(GameUpdateDto dto)
    {
        var game = _mapper.Map<Game>(dto);

        _context.Games.Update(game);
        await _context.SaveChangesAsync();

        return new Result<Game>()
        {
            Data = game,
            Success = true,
            Message = "Successfull"
        };
    }

    public async Task<Result<Game>> Delete(Guid id)
    {
        var game = await _context.Games.FindAsync(id);

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return new Result<Game>()
        {
            Message = "Successfull",
            Success = true
        };
    }

    public async Task<Result<List<GameResponseDto>>> GetAll()
    {
        var games = await _context.Games.ToListAsync();

        var response = _mapper.Map<List<GameResponseDto>>(games);

        return new Result<List<GameResponseDto>>()
        {
            Message = "Successfull",
            Success = true,
            Data = response
        };
    }

    public async Task<Result<GameResponseDto>> GetById(Guid id)
    {
        var game = await _context.Games.FindAsync(id);
        var response = _mapper.Map<GameResponseDto>(game);

        return new Result<GameResponseDto>()
        {
            Message = "Successfull",
            Success = true,
             Data = response
        };

    }

    public async Task<Result<List<GameResponseDto>>> GetAllByCategoryId(Guid categoryId)
    {
        var games = await _context.Games.Where(x => x.CategoryId == categoryId).ToListAsync();

        var response = _mapper.Map<List<GameResponseDto>>(games);
        return new Result<List<GameResponseDto>>()
        {
            Message = "Successfull",
            Success = true,
            Data = response
        };
    }
}