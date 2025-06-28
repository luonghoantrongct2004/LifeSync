using LifeSync.Application.Books.DTOs;
using LifeSync.Application.Books.Interfaces;
using LifeSync.Domain.Books;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace LifeSync.Application.Books.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IDistributedCache _cache;
    private const string BookListCacheKey = "book_list";

    public BookService(IBookRepository bookRepository, IDistributedCache cache)
    {
        _bookRepository = bookRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var cached = await _cache.GetStringAsync(BookListCacheKey);
        if (!string.IsNullOrEmpty(cached))
        {
            return JsonSerializer.Deserialize<IEnumerable<BookDto>>(cached)!;
        }

        var bookEntities = await _bookRepository.GetAllAsync();
        var result = bookEntities.Select(bookEntity => new BookDto
        {
            Id = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            Language = bookEntity.Language.ToString(),
            Description = bookEntity.Description,
            PdfUrl = bookEntity.PdfUrl
        }).ToList();

        await _cache.SetStringAsync(BookListCacheKey, JsonSerializer.Serialize(result),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

        return result;
    }

    public async Task<BookDto?> GetByIdAsync(Guid id)
    {
        var bookEntity = await _bookRepository.GetByIdAsync(id);
        if (bookEntity == null) return null;
        return new BookDto
        {
            Id = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            Language = bookEntity.Language.ToString(),
            Description = bookEntity.Description,
            PdfUrl = bookEntity.PdfUrl
        };
    }

    public async Task<BookDto> AddAsync(BookDto bookDto)
    {
        var bookEntity = new Book
        {
            Id = Guid.NewGuid(),
            Title = bookDto.Title,
            Author = bookDto.Author ?? string.Empty,
            Language = Enum.Parse<LifeSync.Domain.Common.Enums.Language>(bookDto.Language ?? "Vietnamese"),
            Description = bookDto.Description,
            PdfUrl = bookDto.PdfUrl
        };
        await _bookRepository.AddAsync(bookEntity);
        return new BookDto
        {
            Id = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            Language = bookEntity.Language.ToString(),
            Description = bookEntity.Description,
            PdfUrl = bookEntity.PdfUrl
        };
    }

    public async Task<bool> UpdateAsync(Guid id, BookDto bookDto)
    {
        var bookEntity = await _bookRepository.GetByIdAsync(id);
        if (bookEntity == null) return false;
        bookEntity.Title = bookDto.Title;
        bookEntity.Author = bookDto.Author ?? string.Empty;
        bookEntity.Language = Enum.Parse<LifeSync.Domain.Common.Enums.Language>(bookDto.Language ?? "Vietnamese");
        bookEntity.Description = bookDto.Description;
        bookEntity.PdfUrl = bookDto.PdfUrl;
        await _bookRepository.UpdateAsync(bookEntity);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var bookEntity = await _bookRepository.GetByIdAsync(id);
        if (bookEntity == null) return false;
        await _bookRepository.DeleteAsync(id);
        return true;
    }
} 