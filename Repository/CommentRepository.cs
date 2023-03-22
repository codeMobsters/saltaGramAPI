using SaltGram.API.Data;
using SaltGram.API.Models;
using SaltGram.API.Repository.IRepository;

namespace SaltGram.API.Repository;

public class CommentRepository : GenericRepositoryAsync<Comment>, ICommentRepository
{
    private readonly ApplicationDbContext _db;

    public CommentRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}