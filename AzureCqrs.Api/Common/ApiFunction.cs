using AzureCqrs.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureCqrs.Api.Common;

public abstract class ApiFunction
{
    /// <summary>
    /// Get action result for specified operation result.
    /// </summary>
    /// <param name="operationResult"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IActionResult GetActionResult<T>(OperationResult<T> operationResult)
    {
        if (operationResult.Succeeded && operationResult.Value != null)
        {
            return new ObjectResult(operationResult);
        }

        if (operationResult.Succeeded)
        {
            return new NoContentResult();
        }

        return new BadRequestObjectResult(operationResult);
    }
}