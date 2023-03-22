namespace SaltGram.API.Services;

public interface IImageStorageService
{
    Task<string> UploadFile(Stream fileStream, string fileName, string contentType);
}