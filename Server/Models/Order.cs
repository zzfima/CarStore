namespace Server.Models;

public partial class Order
{
    public int Id { get; set; }
    public int SampleId { get; set; }
    public virtual Sample Sample { get; set; } = null!;
}