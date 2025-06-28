using Xunit;
using Moq;
using LifeSync.Application.Books.Services;
using LifeSync.Application.Books.Interfaces;
using LifeSync.Domain.Books;
using LifeSync.Application.Books.DTOs;
using FluentAssertions;

public class BookServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllBooks()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new[]
        {
            new Book { Id = Guid.NewGuid(), Title = "Book 1" },
            new Book { Id = Guid.NewGuid(), Title = "Book 2" }
        });
        var service = new BookService(mockRepo.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(b => b.Title == "Book 1");
        result.Should().Contain(b => b.Title == "Book 2");
    }

    [Fact]
    public async Task AddAsync_AddsBookAndReturnsDto()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        var service = new BookService(mockRepo.Object);
        var dto = new BookDto { Title = "New Book" };

        // Act
        var result = await service.AddAsync(dto);

        // Assert
        result.Title.Should().Be("New Book");
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Book>()), Times.Once);
    }
} 