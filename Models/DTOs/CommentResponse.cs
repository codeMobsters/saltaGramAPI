using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SaltGram.API.Models;

public class CommentResponse
{
    public int CommentId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CommentText { get; set; }
}