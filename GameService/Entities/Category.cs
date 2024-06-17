namespace GameService.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Game> Games { get; set; }

    public Category()
    {
        Games = new HashSet<Game>();
    }
    
}