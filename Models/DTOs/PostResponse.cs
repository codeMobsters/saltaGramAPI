namespace SaltGram.API.Models.DTOs;

public class PostResponse
{
    public int PostId { get; set; }
    string PictureUrl { get; set; }
    public DateTime UploadedAt { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    public List<CommentResponse> Comments { get; set; }
}

