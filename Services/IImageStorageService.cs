namespace SaltGram.API.Services;

public interface IImageStorageService
{
    Task<string> UploadFile();
}