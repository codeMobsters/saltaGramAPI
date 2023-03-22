using SaltGram.API.Data;
using SaltGram.API.Repository.IRepository;

namespace SaltGram.API.Repository;

public class Repositories : IRepositories
{
    private ApplicationDbContext _db;
    public IPostRepository Post { get; }
    public ICommentRepository Comment { get; }
    // public IUserRepository User { get; }
    
    public Repositories(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        // User = new UserRepository(_db, configuration);
        Post = new PostRepository(_db);
        Comment = new CommentRepository(_db);
    }
    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}