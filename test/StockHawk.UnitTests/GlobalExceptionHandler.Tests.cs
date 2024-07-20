using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace StockHawk.UnitTests;
public class GlobalExceptionHandlerTests
{
    private readonly Mock<ILogger<GlobalExceptionHandler>> _mockLogger;
    private readonly GlobalExceptionHandler _exceptionHandler;

    public GlobalExceptionHandlerTests()
    {
        _mockLogger = new Mock<ILogger<GlobalExceptionHandler>>();
        _exceptionHandler = new GlobalExceptionHandler(_mockLogger.Object);
    }

    [Fact]
    public async Task TryHandleAsync_LogsError()
    {
        // REF: https://stackoverflow.com/questions/66307477/how-to-verify-iloggert-log-extension-method-has-been-called-using-moq
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new Exception("Test exception");
        var cancellationToken = CancellationToken.None;

        // Act
        await _exceptionHandler.TryHandleAsync(context, exception, cancellationToken);

        // Assert
        _mockLogger.Verify(
            logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == $"Exception occurred: {exception.Message}" && @type.Name == "FormattedLogValues"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
    }
    [Fact]
    public async Task TryHandleAsync_SetsContextResponseStatusCodeTo500()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new Exception("Test exception");
        var cancellationToken = CancellationToken.None;

        // Act
        await _exceptionHandler.TryHandleAsync(context, exception, cancellationToken);

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
    }

    [Fact]
    public async Task TryHandleAsync_WritesProblemDetailsToResponse()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();
        var exception = new Exception("Test exception");
        var cancellationToken = CancellationToken.None;

        // Act
        await _exceptionHandler.TryHandleAsync(context, exception, cancellationToken);

        // Assert
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var response = new StreamReader(context.Response.Body).ReadToEnd();
        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(response);

        Assert.Equal(StatusCodes.Status500InternalServerError, problemDetails?.Status);
        Assert.Equal("Server error", problemDetails?.Title);
    }
}
