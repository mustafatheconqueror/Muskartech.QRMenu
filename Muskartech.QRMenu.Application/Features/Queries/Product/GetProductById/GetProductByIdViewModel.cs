namespace Muskartech.QRMenu.Application.Features.Queries.Product;

public class GetProductByIdViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string CategoryId { get; set; }
}