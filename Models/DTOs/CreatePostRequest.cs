namespace SaltGram.API.Models.DTOs;

public class CreatePostRequest
{
    public IFormFile FormFile { get; set; }
    public string Description { get; set; }
}