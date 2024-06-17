namespace GameService.Entities;

public class GameImage : Entity
{
    public string ImageUrl { get; set; }

    public Game Game { get; set; }
    public Guid GameId { get; set; }
    
    
}