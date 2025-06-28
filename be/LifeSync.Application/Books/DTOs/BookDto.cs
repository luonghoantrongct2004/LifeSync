namespace LifeSync.Application.Books.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Author { get; set; }
    public string? Language { get; set; }
    public string? Description { get; set; }
    public string? PdfUrl { get; set; }
} 