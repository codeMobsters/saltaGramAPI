using Microsoft.AspNetCore.Mvc;
using SaltGram.API.Models;
using SaltGram.API.Services;

namespace SaltGram.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IImageStorageService _imageStorageService;

    public PostsController(IImageStorageService imageStorageService)
    {
        _imageStorageService = imageStorageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TestPicture>>> GetPosts()
    {
        var response = new List<TestPicture>();
        response.Add(new TestPicture() {url = await _imageStorageService.UploadFile()});
        return response;
    }
}