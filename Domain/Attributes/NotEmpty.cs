namespace Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotEmpty:Attribute
{
    public string Message { get; set; }

    public NotEmpty(string message)
    {
        Message = message;
    }
}