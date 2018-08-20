namespace BMB.Core.BoxManagement
{
    using Listener;

    public interface IProcessHandler
    {
        void HandleProcess(ProcessStartedEventArgs eventArgs);
    }
}