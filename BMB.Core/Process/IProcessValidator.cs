namespace BMB.Core.Process
{
    public interface IProcessValidator
    {
        bool ValidateProcess(ProcessStartedEventArgs eventArgs);
    }
}