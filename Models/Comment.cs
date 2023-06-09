using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SaltGram.API.Models;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public string CommentText { get; set; }
    [Required]
    [ForeignKey("Post")]
    public int PostId { get; set; }
}