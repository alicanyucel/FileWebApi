using First.WebAPI.DTOs;
using First.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> Products { get; set; } = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }

    [HttpPost]
    public IActionResult Create([FromForm] CreateProductDto request)
    {

        #region CheckAvatarByteForMimeTypeFormat
        using(var memoryStream = new MemoryStream())
        {
            request.Avatar.CopyTo(memoryStream);
            var checkBytes = memoryStream.ToArray(); //jpg 255 216 255 225 exe => 77 90 144 0

            string checkBytesTypeString = string.Join(
                "", 
                checkBytes[0].ToString(), 
                checkBytes[1].ToString(), 
                checkBytes[2].ToString(),
                checkBytes[3].ToString()
                );

            if (checkBytesTypeString != "255216255225")
            {
                return BadRequest(new { Message = "Sadece resim dosyaları yüklenebilir!" });
            }
        }
        #endregion

        #region Avatar File Save
        string avatarFileName = string.Join("-", DateTime.Now.ToFileTime(), request.Avatar.FileName);
        using (FileStream stream = System.IO.File.Create($"wwwroot/avatars/{avatarFileName}")) 
        {
            request.Avatar.CopyTo(stream);
        }
        #endregion

        #region Image Files Save
        List<string> imageUrls = new();

        foreach (var file in request.Images)
        {
            string imageFileName = string.Join("-",DateTime.Now.ToFileTime(), file.FileName);
            using (var stream = System.IO.File.Create($"wwwroot/images/{imageFileName}"))
            {
                file.CopyTo(stream);
            }

            imageUrls.Add(imageFileName);
        }
        #endregion

        #region Avatar Convert Byte
        byte[] avatar = new byte[128];

        using(var memoryStream = new MemoryStream())
        {            
             request.Avatar.CopyTo(memoryStream);

            avatar = memoryStream.ToArray();
        }
        #endregion

        #region Create Product Object
        Product product = new()
        {
            Name = request.Name,
            Price = request.Price,
            AvatarUrl = avatarFileName,
            ImageUrls = string.Join(",", imageUrls),
            Avatar = avatar,
        };
        #endregion

        Products.Add(product);

        return Created();

        //backend'e dosyamı saklayabilirim
        //cloud sistemlerine saklayabilirim
        //ftp dosyasına saklayabilirim
        //bilgisayarımdaki bir klasöre saklayabilirim
    }
}
