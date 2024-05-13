namespace First.WebAPI.Models;

public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public string ImageUrls { get; set; } = string.Empty;
    public byte[] Avatar { get; set; } = new byte[128];

}
