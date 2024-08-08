namespace StockHawk.Service.Exceptions;

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string message) : base(message) { }
}