namespace BMB.Core.BoxManagement
{
    using Listener;

    public interface IBoxRepository
    {
        void AddBoxToCache(ProcessStartedEventArgs eventArgs);
    }
}