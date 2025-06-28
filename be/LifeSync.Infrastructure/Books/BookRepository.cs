using LifeSync.Application.Books.Interfaces;
using LifeSync.Domain.Books;
using LifeSync.Domain.Common.Enums;
using LifeSync.Infrastructure.Common;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Books;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetByAuthorAsync(string author)
    {
        return await _dbSet
            .Where(b => b.Author.Contains(author))
            .OrderByDescending(b => b.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByTitleAsync(string title)
    {
        return await _dbSet
            .Where(b => b.Title.Contains(title))
            .OrderByDescending(b => b.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByStatusAsync(BookStatus status)
    {
        return await _dbSet
            .Where(b => b.Status == status)
            .OrderByDescending(b => b.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByLanguageAsync(Language language)
    {
        return await _dbSet
            .Where(b => b.Language == language)
            .OrderByDescending(b => b.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }
} 