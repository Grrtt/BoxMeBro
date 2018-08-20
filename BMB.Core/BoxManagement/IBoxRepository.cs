namespace BMB.Core.BoxManagement
{
    using Listener;

    public interface IBoxRepository
    {
        void AddBoxForProcess(ProcessStartedEventArgs eventArgs);
    }
}