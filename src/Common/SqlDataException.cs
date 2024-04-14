namespace SimpleInventoryManagementSystem.Common;

public class SqlDataException : PrintableException
{
    public SqlDataException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}