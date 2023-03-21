using Azure;
using Azure.Data.Tables;

namespace SaltGram.API.Models;

public class Post :ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    // public int UserId { get; set; }
    // public virtual User? User { get; set; }
    public string PictureUrl { get; set; }
    public DateTime UploadedDate { get; set; }
    public string Description { get; set; }
    public string[] CommentKeys { get; set; }
    public int Likes { get; set; }
}


