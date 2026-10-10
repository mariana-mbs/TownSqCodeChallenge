public class Community
{
    public string Name { get; set; } = string.Empty;
    public Address Address  { get; set; } = new Address();
    public List<Unit> Units { get; set; } = new List<Unit>();
}