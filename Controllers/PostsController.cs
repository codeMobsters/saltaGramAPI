using Microsoft.AspNetCore.Mvc;
using SaltGram.API.Models;
using SaltGram.API.Models.DTOs;
using SaltGram.API.Repository.IRepository;
using SaltGram.API.Services;

namespace SaltGram.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IImageStorageService _imageStorageService;
    private readonly IRepositories _repositories;

    public PostsController(IImageStorageService imageStorageService, IRepositories repositories)
    {
        _imageStorageService = imageStorageService;
        _repositories = repositories;
    }

    // [HttpGet]
    // public async Task<ActionResult<List<TestPicture>>> GetPosts()
    // {
    //     var response = new List<TestPicture>();
    //     response.Add(new TestPicture() { url = await _imageStorageService.UploadFile() });
    //     return response;
    // }
    
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPosts(string? searchTerm)
    {
        if (_repositories.Post == null)
        {
            return NotFound();
        }

        if (string.IsNullOrEmpty(searchTerm))
        {
            return await _repositories.Post.GetAllAsync();
        }
        
        return await _repositories.Post.GetAllAsync(post => post.Description.ToLower().Contains(searchTerm.ToLower()));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetRecipe(int id)
    {
        if (_repositories.Post == null)
        {
            return NotFound();
        }
        
        var post = await _repositories.Post.GetFirstOrDefaultAsync(c => c.PostId == id);
        
        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    [HttpPost]
    [Consumes("multipart/form-data")] 
    public async Task<ActionResult<Post>> PostPost([FromForm] CreatePostRequest request)
    {
        var newPost = new Post()
        {
            PictureUrl = await _imageStorageService.UploadFile(request.FormFile.OpenReadStream(),
                request.FormFile.FileName, request.FormFile.ContentType),
            UploadedAt = DateTime.Now,
            Description = request.Description,
            Likes = 0
        };

        await _repositories.Post.AddAsync(newPost);
        await _repositories.Save();
        
        return CreatedAtAction("GetRecipe", new { id = newPost.PostId }, newPost);
    }

    // [HttpPost]
    // public async Task<ActionResult<Recipe>> PostRecipe(RecipeTransfer newRecipe, string token)
    // {
    //     if (_repositories.Recipe == null)
    //     {
    //         return Problem("Entity set 'RecipeContext.Recipe'  is null.");
    //     }
    //         
    //     var recipe = _mapper.Map<Recipe>(newRecipe);
    //     recipe.Id = 0;
    //     recipe.UserId = GetIdFromToken(token);
    //     
    //     await _repositories.Recipe.AddAsync(recipe);
    //     await _repositories.Save();
    //     
    //     return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
    // }
}