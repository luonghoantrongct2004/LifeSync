using Xunit;
using Moq;
using LifeSync.Application.Finance.Services;
using LifeSync.Application.Finance.Interfaces;
using LifeSync.Domain.Finance;
using LifeSync.Application.Finance.DTOs;
using FluentAssertions;

public class TransactionServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllTransactions()
    {
        var mockRepo = new Mock<ITransactionRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new[]
        {
            new Transaction { Id = Guid.NewGuid(), Amount = 100 },
            new Transaction { Id = Guid.NewGuid(), Amount = 200 }
        });
        var service = new TransactionService(mockRepo.Object);

        var result = await service.GetAllAsync();

        result.Should().HaveCount(2);
        result.Should().Contain(t => t.Amount == 100);
        result.Should().Contain(t => t.Amount == 200);
    }

    [Fact]
    public async Task AddAsync_AddsTransactionAndReturnsDto()
    {
        var mockRepo = new Mock<ITransactionRepository>();
        var service = new TransactionService(mockRepo.Object);
        var dto = new TransactionDto { Amount = 500, Description = "Test" };

        var result = await service.AddAsync(dto);

        result.Amount.Should().Be(500);
        result.Description.Should().Be("Test");
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Transaction>()), Times.Once);
    }
} 