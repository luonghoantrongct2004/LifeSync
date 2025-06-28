using LifeSync.Domain.Books;
using LifeSync.Domain.Common.Enums;
using LifeSync.Application.Common.Interfaces;

namespace LifeSync.Application.Books.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<IEnumerable<Book>> GetByAuthorAsync(string author);
    Task<IEnumerable<Book>> GetByTitleAsync(string title);
    Task<IEnumerable<Book>> GetByStatusAsync(BookStatus status);
    Task<IEnumerable<Book>> GetByLanguageAsync(Language language);
} 