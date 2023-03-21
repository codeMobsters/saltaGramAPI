using Azure;
using Azure.Data.Tables;

namespace SaltGram.API.Models;

public class User: ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public int UserId { get; set; }
    public string Name { get; set; }
    public string ProfilePictureUrl { get; set; }
}