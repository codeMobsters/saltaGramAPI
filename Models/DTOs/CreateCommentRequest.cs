namespace SaltGram.API.Models.DTOs;

public class CreateCommentRequest
{
    public string Name { get; set; }
    public string CommentText { get; set; }
    public int PostId { get; set; }
}