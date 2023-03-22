namespace SaltGram.API.Repository.IRepository;

public interface IRepositories
{
    IPostRepository Post { get; }
    ICommentRepository Comment { get; }
    // IUserRepository User { get; }
    Task Save();
}