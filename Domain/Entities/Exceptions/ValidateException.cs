namespace Domain.Entities;

public class ValidateException : Exception
{
    public object? Errors;
    public ValidateException(string message, object? errors = null) : base(message)
    {
        Errors = errors;
    }
}