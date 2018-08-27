namespace BMB.Core.Process
{
    public interface IProcessHandler
    {
        void HandleProcess(ProcessStartedEventArgs eventArgs);

        void HandleProcess(ProcessStoppedEventArgs eventArgs);
    }
}