using Azure;
using Azure.Data.Tables;

namespace SaltGram.API.Models;

public class Comment :ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public int CommentId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAtDate { get; set; }
    public string CommentText { get; set; }
}