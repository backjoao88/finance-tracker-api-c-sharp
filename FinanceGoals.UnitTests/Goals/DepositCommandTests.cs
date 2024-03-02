using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Core.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace FinanceGoals.UnitTests.Goals;

public class DepositCommandTests
{
    private readonly IUnitOfWork _unitOfWorkMock;

    public DepositCommandTests()
    {
        var goalRepositoryMock = Substitute.For<IGoalRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _unitOfWorkMock.GoalRepository.Returns(goalRepositoryMock);
    }

    /// <summary>
    /// Tests if the service returns error when a goal not exists.
    /// </summary>
    [Fact]
    public async void HandlerShouldReturnErrorIfGoalNotExists()
    {
        // Arrange
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .ReturnsNull();
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var handler = new DepositCommandHandler(_unitOfWorkMock, goalService);
        var result = await handler.Handle(new DepositCommand(Guid.NewGuid(), 10M), CancellationToken.None);
        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Tests if the service returns error when a transaction is invalid.
    /// </summary>
    [Fact]
    public async void HandlerShouldReturnErrorIfTransactionIsInvalid()
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10.000M, 1.000M, 1);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var handler = new DepositCommandHandler(_unitOfWorkMock, goalService);
        var result = await handler.Handle(new DepositCommand(Guid.NewGuid(), -100M), CancellationToken.None);
        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(result.Error, DomainErrors.Transaction.NotNegative);
    }

    /// <summary>
    /// Tests if handler returns ok when a deposit is performed.
    /// </summary>
    [Fact]
    public async void HandlerShouldReturnOkIfDepositIsPerformed()
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10.000M, 1.000M, 1);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var handler = new DepositCommandHandler(_unitOfWorkMock, goalService);
        var result = await handler.Handle(new DepositCommand(Guid.NewGuid(), 100M), CancellationToken.None);
        // Assert
        Assert.True(result.IsSuccess);
        await _unitOfWorkMock.Received(1).Complete();
    }

    /// <summary>
    /// Tests if handler increases correctly the balance when two deposits are performed.
    /// </summary>
    /// <param name="expectedAmount"></param>
    /// <param name="one"></param>
    /// <param name="two"></param>
    [Theory]
    [InlineData(300, 100.00, 200.00)]
    [InlineData(555.50, 55.50, 500.00)]
    public async void HandlerShouldIncreaseAmountIfTwoDepositsArePerformed(decimal expectedAmount, decimal one, decimal two)
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10.000M, 1.000M,1);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var deposits = new decimal[] { one, two };
        foreach (var deposit in deposits)
        {
            var handler = new DepositCommandHandler(_unitOfWorkMock, goalService);
            var result =
                await handler.Handle(new DepositCommand(Guid.NewGuid(), deposit), CancellationToken.None);
        }
        // Assert
        Assert.Equal(expectedAmount, goal.TotalAmount);
    }
}