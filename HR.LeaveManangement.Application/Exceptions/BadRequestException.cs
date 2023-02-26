using FluentValidation.Results;

namespace HR.LeaveManangement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        ValidationErrors = new();
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();

        foreach(var error in validationResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }

    }

    public List<string> ValidationErrors { get; set; }

}