using GameService.Dtos.Games;
using GameService.Entities;
using GameService.ReturnModels;

namespace GameService.Repositories;

public interface IGameRepository
{
    Task<Result<Game>> Create(GameCreateDto dto);
    Task<Result<Game>> Update(GameUpdateDto dto);
    Task<Result<Game>> Delete(Guid id);
    Task<Result<List<GameResponseDto>>> GetAll();
    Task<Result<GameResponseDto>> GetById(Guid id);

    Task<Result<List<GameResponseDto>>> GetAllByCategoryId(Guid categoryId);

}