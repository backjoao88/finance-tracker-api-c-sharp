using FinanceGoals.Core.Primitives.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinanceGoals.Api.Abstractions;

/// <summary>
/// Represents a base controller.
/// </summary>
public class ApiController : ControllerBase
{
    public IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new []{ error }));
    public IActionResult NotFound(Error error) => NotFound(new ApiErrorResponse(new[] { error }));
}