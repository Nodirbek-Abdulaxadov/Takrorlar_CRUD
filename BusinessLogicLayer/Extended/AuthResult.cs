namespace BusinessLogicLayer.Extended;
public class AuthResult(bool IsSuccess, IEnumerable<string>? ErrorMessages)
{
    public bool IsSuccess { get; } = IsSuccess;
    public IEnumerable<string>? ErrorMessages { get; } = ErrorMessages;
}