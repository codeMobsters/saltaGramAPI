using Azure;
using Azure.Data.Tables;

namespace SaltGram.API.Models;

public class Picture :ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public int PictureId { get; set; }
    public DateTime UploadedDate { get; set; }
    public int Likes { get; set; }
    public string Description { get; set; }
}