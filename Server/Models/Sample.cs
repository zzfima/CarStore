namespace Server.Models;

public partial class Sample
{
    public int Id { get; set; }
    public int BodyTypeId { get; set; }
    public int ManufacturerId { get; set; }
    public string? Name { get; set; }
    public virtual BodyType BodyType { get; set; } = null!;
    public virtual Manufacturer Manufacturer { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}