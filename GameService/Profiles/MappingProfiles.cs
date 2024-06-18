using AutoMapper;
using GameService.Dtos;
using GameService.Dtos.Games;
using GameService.Entities;

namespace GameService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<GameCreateDto, Game>();
        CreateMap<GameUpdateDto, Game>();
        CreateMap<Game, GameResponseDto>();


    }
}