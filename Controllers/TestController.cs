using First.WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace First.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    //[HttpGet("{age}/{name}")] //Route params
    [HttpGet] //Query Params
    public IActionResult Read(int age, string name)
    {
        Result4 result = Result4.Successful("API is working...");        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(CreateDto request, int age)
    {
        //db kayıt işlemleri
        return Ok(Result3.Successful("Create is successful"));
    }

    [HttpPut]
    public IActionResult Update(ProductTest product)
    {
        //update işlemi
        return Ok(Result4.Successful("Update is successful"));
    }

    [HttpDelete]
    public IActionResult Delete(User user, int id)
    {
        return Ok(Result4.Successful("Delete is successful"));
    }
}
public class User
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ProductTest
{
    public string Name { get; set; } = string.Empty;
}

public class CreateDto
{
    public User User { get; set; } = new();
    public ProductTest Product { get; set; } = new();
}