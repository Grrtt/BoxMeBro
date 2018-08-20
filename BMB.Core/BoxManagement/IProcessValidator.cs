namespace BMB.Core.BoxManagement
{
    using Listener;

    public interface IProcessValidator
    {
        bool ValidateProcess(ProcessStartedEventArgs eventArgs);
    }
}