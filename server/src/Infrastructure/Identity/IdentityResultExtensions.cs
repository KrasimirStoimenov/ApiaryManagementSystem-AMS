﻿namespace ApiaryManagementSystem.Infrastructure.Identity;

using ApiaryManagementSystem.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
