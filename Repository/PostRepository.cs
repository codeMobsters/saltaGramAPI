using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SaltGram.API.Data;
using SaltGram.API.Models;
using SaltGram.API.Repository.IRepository;

namespace SaltGram.API.Repository;

public class PostRepository : GenericRepositoryAsync<Post>, IPostRepository
{
    private readonly ApplicationDbContext _db;

    public PostRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public override async Task<List<Post>> GetAllAsync(Expression<Func<Post, bool>>? filter = null)
    {
        IQueryable<Post> query = _db.Posts;
        
        if (filter != null)
        {
            query = query.Where(filter);
        }
        
        return await query.Include(post => post.Comments).ToListAsync();
    }
}