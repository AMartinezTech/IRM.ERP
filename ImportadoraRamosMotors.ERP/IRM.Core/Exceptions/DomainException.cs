namespace IRM.Core.Exceptions;

public abstract class DomainException(string message) : Exception(message)
{
}

public class ValidationException(string message) : DomainException(message)
{
}

public class BusinessRuleException(string message) : DomainException(message)
{
}
