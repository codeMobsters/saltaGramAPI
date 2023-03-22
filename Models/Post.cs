using System.ComponentModel.DataAnnotations;
using Azure;
using Azure.Data.Tables;

namespace SaltGram.API.Models;

public class Post
{
    [Key] 
    public int PostId { get; set; }
    [Required]
    public string PictureUrl { get; set; }
    [Required]
    public DateTime UploadedAt { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Likes { get; set; }
    
    public virtual List<Comment> Comments { get; set; }

    // public int UserId { get; set; }
    // public virtual User? User { get; set; }
}

