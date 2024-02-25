using FinanceGoals.Application.Commands.Transactions.Create;
using FinanceGoals.Core;
using FinanceGoals.Core.Enumerations;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace FinanceGoals.UnitTests.Transactions;

/// <summary>
/// Represents a set of unit tests for the create transaction handler.
/// </summary>
public class CreateTransactionCommandTests
{
    private readonly CreateTransactionCommandHandler _handlerMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public CreateTransactionCommandTests()
    {
        var goalRepository = Substitute.For<IGoalRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _unitOfWorkMock.GoalRepository.Returns(goalRepository);
        _handlerMock = new CreateTransactionCommandHandler(_unitOfWorkMock);
    }
    
    /// <summary>
    /// Checks if the handler return an error when goal not exists, while trying to create a transaction.
    /// </summary>
    [Fact]
    public async void HandlerShouldReturnErrorWhenGoalNotExists()
    {
        var idGoal = Guid.NewGuid();
        _unitOfWorkMock.GoalRepository.ReadById(Arg.Is<Guid>(o => o == idGoal)).ReturnsNull();
        var createTransactionCommand = new CreateTransactionCommand(Guid.NewGuid(), 10.00M, TransactionTypeEnum.Deposit);
        var result = await _handlerMock.Handle(createTransactionCommand, CancellationToken.None);
        Assert.Equal(result.Error, DomainErrors.Goal.TotalNotNegative);
    }
}