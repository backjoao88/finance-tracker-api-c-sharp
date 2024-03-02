using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Application.Commands.Goals.Withdraw;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Core.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace FinanceGoals.UnitTests.Goals;

public class WithdrawCommandTests
{
    private readonly IUnitOfWork _unitOfWorkMock;

    public WithdrawCommandTests()
    {
        var goalRepository = Substitute.For<IGoalRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _unitOfWorkMock.GoalRepository.Returns(goalRepository);
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
        var handler = new WithdrawCommandHandler(_unitOfWorkMock, goalService);
        var result = await handler.Handle(new WithdrawCommand(Guid.NewGuid(), 10M), CancellationToken.None);
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
    /// Tests if handler returns ok when a withdraw is performed.
    /// </summary>
    [Fact]
    public async void HandlerShouldReturnOkIfWithdrawIsPerformed()
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10000M, 1000M, 1, 10000M);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var handler = new WithdrawCommandHandler(_unitOfWorkMock, goalService);
        var result = await handler.Handle(new WithdrawCommand(Guid.NewGuid(), 100M), CancellationToken.None);
        // Assert
        Assert.True(result.IsSuccess);
        await _unitOfWorkMock.Received(1).Complete();
    }

    /// <summary>
    /// Tests if handler increases decreases the balance when two withdraws are performed.
    /// </summary>
    /// <param name="withdraw"></param>
    [Theory]
    [InlineData(100.00)]
    [InlineData(55.50)]
    public async void HandlerShouldReturnErrorIfFutureAmountIsNegative(decimal withdraw)
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10.000M, 1.000M, 1);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var handler = new WithdrawCommandHandler(_unitOfWorkMock, goalService);
        var result =
            await handler.Handle(new WithdrawCommand(Guid.NewGuid(), withdraw), CancellationToken.None);
    
        // Assert
        Assert.Equal(DomainErrors.Goal.TotalNotNegative, result.Error);
    }

    /// <summary>
    /// Tests if handler decreases correctly the balance when two withdraws are performed.
    /// </summary>
    /// <param name="expectedAmount"></param>
    /// <param name="one"></param>
    /// <param name="two"></param>
    /// <param name="initialAmount"></param>
    [Theory]
    [InlineData(3200, 100.00, 200.00, 3500.00)]
    [InlineData(1944.50, 55.50, 500.00, 2500.00)]
    public async void HandlerShouldIncreaseAmountIfTwoDepositsArePerformed(decimal expectedAmount, decimal one, decimal two, decimal initialAmount)
    {
        // Arrange
        var goal = new Goal("MyMockedGoal", 10.000M, 1.000M, 1, initialAmount);
        _unitOfWorkMock
            .GoalRepository
            .ReadById(Arg.Any<Guid>())
            .Returns(goal);
        var goalService = new GoalService(_unitOfWorkMock);
        // Act
        var withdraws = new [] { one, two };
        foreach (var withdraw in withdraws)
        {
            var handler = new WithdrawCommandHandler(_unitOfWorkMock, goalService);
            var result =
                await handler.Handle(new WithdrawCommand(Guid.NewGuid(), withdraw), CancellationToken.None);
        }
        // Assert
        Assert.Equal(expectedAmount, goal.TotalAmount);
    }
    
}