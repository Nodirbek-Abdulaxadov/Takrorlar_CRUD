namespace BusinessLogicLayer.Extended;
public class ComputerException(string message) 
    : Exception
{
    public string ErrorMessage = message;
}