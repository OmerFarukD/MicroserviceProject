using GameService.Dtos.Games;
using GameService.Entities;
using GameService.ReturnModels;

namespace GameService.Repositories;

public interface IGameRepository
{
    Task<Result<Game>> Create(GameCreateDto dto);
}