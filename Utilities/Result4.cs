namespace First.WebAPI.Utilities;

public record Result4(string Message)
{
    public static Result4 Successful(string message)
    {
        return new(message);
    }
}