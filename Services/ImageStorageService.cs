using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace SaltGram.API.Services;

public class ImageStorageService : IImageStorageService
{
    private IConfiguration _configuration;
    
    public ImageStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> UploadFile(Stream fileStream, string fileName, string contentType)
    {
        // Retrieve the connection string for use with the application. 
        string connectionString = _configuration.GetConnectionString("AZURE_STORAGE_CONNECTION_STRING");
        

        // Create a BlobServiceClient object 
        var blobServiceClient = new BlobServiceClient(connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient("images");

        // Upload
        var blobClient = containerClient.GetBlobClient(fileName);
        
        var blobHttpHeader = new BlobHttpHeaders();
        
        blobHttpHeader.ContentType = contentType;
        
        await blobClient.UploadAsync(fileStream, blobHttpHeader);
        
        return blobClient.Uri.ToString();
    }
}
