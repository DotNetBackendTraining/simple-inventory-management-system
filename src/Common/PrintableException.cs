namespace SimpleInventoryManagementSystem.Common;

public abstract class PrintableException : Exception
{
    protected PrintableException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public override string ToString() => $"Error: {Message}\nDetails: {InnerException?.Message}";
}