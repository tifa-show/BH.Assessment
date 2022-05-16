using FluentValidation.Results;

namespace BH.Assessment.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors) ValidationErrors.Add(error.ErrorMessage);
    }

    public List<string> ValidationErrors { get; set; } = new();
}