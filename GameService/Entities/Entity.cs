namespace GameService.Entities;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    
    
    public Guid Id { get; set; }

    public DateTime CreatedTime { get; set; }
}