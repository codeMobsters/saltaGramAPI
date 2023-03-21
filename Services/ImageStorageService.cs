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

    public async Task<string> UploadFile()
    {
        // Retrieve the connection string for use with the application. 
        string connectionString = _configuration.GetConnectionString("CUSTOMCONNSTR_AZURE_STORAGE_CONNECTION_STRING");
        

        // Create a BlobServiceClient object 
        var blobServiceClient = new BlobServiceClient(connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient("images");
        

        string localPath = "./Data/";
        string localFilePath = Path.Combine(localPath, "aPicture.gif");

        // Upload
        string fileName = "aPicture.gif";
        var blobClient = containerClient.GetBlobClient(fileName);
        
        // var blobHttpHeader = new BlobHttpHeaders();
        //
        // blobHttpHeader.ContentType = "image/gif";
        //
        // await blobClient.UploadAsync(localFilePath, blobHttpHeader);
        
        return blobClient.Uri.ToString();
    }
}
