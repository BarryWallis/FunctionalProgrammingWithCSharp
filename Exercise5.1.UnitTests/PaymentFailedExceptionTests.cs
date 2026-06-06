using System;

namespace Exercise5._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise5._1.PaymentFailedException"/>.
/// </summary>
public class PaymentFailedExceptionTests
{
    /// <summary>
    /// Verifies that the parameterless constructor creates the exception without an inner exception.
    /// </summary>
    [Fact]
    public void PaymentFailedException_NoArgumentsProvided_CreatesExceptionWithoutInnerException()
    {
        global::Exercise5._1.PaymentFailedException sut = new();

        Assert.NotNull(sut.Message);
        Assert.Null(sut.InnerException);
    }

    /// <summary>
    /// Verifies that the constructor stores the provided message.
    /// </summary>
    [Fact]
    public void PaymentFailedException_MessageIsProvided_SetsMessage()
    {
        string message = "Payment was declined.";

        global::Exercise5._1.PaymentFailedException sut = new(message);

        Assert.Equal(message, sut.Message);
        Assert.Null(sut.InnerException);
    }

    /// <summary>
    /// Verifies that the constructor stores the provided message and inner exception.
    /// </summary>
    [Fact]
    public void PaymentFailedException_MessageAndInnerExceptionAreProvided_SetsProperties()
    {
        string message = "Payment authorization failed.";
        Exception innerException = new("Gateway timeout.");

        global::Exercise5._1.PaymentFailedException sut = new(message, innerException);

        Assert.Equal(message, sut.Message);
        Assert.Same(innerException, sut.InnerException);
    }

    /// <summary>
    /// Verifies that a null message still creates an exception instance with no inner exception.
    /// </summary>
    [Fact]
    public void PaymentFailedException_NullMessageIsProvided_CreatesExceptionWithoutInnerException()
    {
        string? message = null;
        global::Exercise5._1.PaymentFailedException sut = new(message);

        Assert.NotNull(sut.Message);
        Assert.Null(sut.InnerException);
    }

    /// <summary>
    /// Verifies that the constructor accepts null values for both optional parameters.
    /// </summary>
    [Fact]
    public void PaymentFailedException_NullMessageAndInnerExceptionAreProvided_CreatesExceptionWithoutInnerException()
    {
        string? message = null;
        Exception? innerException = null;
        global::Exercise5._1.PaymentFailedException sut = new(message, innerException);

        Assert.NotNull(sut.Message);
        Assert.Null(sut.InnerException);
    }
}
