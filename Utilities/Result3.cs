namespace First.WebAPI.Utilities;

public class Result3
{
    private Result3(string message)
    {
        Message = message;
    }
    public string Message { get; init; } = string.Empty;

    public static Result3 Successful(string message)
    {
        return new(message);
    }
}
