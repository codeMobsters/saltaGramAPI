using Microsoft.AspNetCore.Mvc;
using SaltGram.API.Models;
using SaltGram.API.Models.DTOs;
using SaltGram.API.Repository.IRepository;
using SaltGram.API.Services;

namespace SaltGram.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IRepositories _repositories;

    public CommentsController(IRepositories repositories)
    {
        _repositories = repositories;
    }

    // [HttpGet]
    // public async Task<ActionResult<List<TestPicture>>> GetPosts()
    // {
    //     var response = new List<TestPicture>();
    //     response.Add(new TestPicture() { url = await _imageStorageService.UploadFile() });
    //     return response;
    // }
    
    // [HttpGet]
    // public async Task<ActionResult<List<Post>>> GetPosts()
    // {
    //     if (_repositories.Post == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var posts =await _repositories.Post.GetAllAsync();
    //     return posts;
    // }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        if (_repositories.Comment == null)
        {
            return NotFound();
        }
        
        var comment = await _repositories.Comment.GetFirstOrDefaultAsync(c => c.CommentId == id);
        
        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment([FromBody] CreateCommentRequest request)
    {
        var newComment = new Comment()
        {
            Name = request.Name,
            CreatedAt = DateTime.Now,
            CommentText = request.CommentText,
            PostId = request.PostId
        };

        await _repositories.Comment.AddAsync(newComment);
        await _repositories.Save();
        
        return CreatedAtAction("GetComment", new { id = newComment.CommentId }, newComment);
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