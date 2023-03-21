using Microsoft.AspNetCore.Mvc;
using SaltGram.API.Models;
using SaltGram.API.Services;

namespace SaltGram.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> GetPosts()
    {
        var test = new ImageStorageService();
        return await test.UploadFile();
    }
}