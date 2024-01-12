namespace Server.Models;

public partial class BodyType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Sample> Samples { get; set; } = new List<Sample>();
}