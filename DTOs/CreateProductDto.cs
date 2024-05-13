namespace First.WebAPI.DTOs;

public record CreateProductDto(
    string Name,
    decimal Price,
    IFormFile Avatar,
    List<IFormFile> Images
    );
