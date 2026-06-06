namespace Exercise5._1;

/// <summary>
/// Represents a failure that occurs when payment is required for a tower upgrade.
/// </summary>
[Serializable]
internal class PaymentFailedException : Exception
{
    public PaymentFailedException()
    {
    }

    public PaymentFailedException(string? message) : base(message)
    {
    }

    public PaymentFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
