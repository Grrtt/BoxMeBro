namespace BMB.Core.Process
{
    using System;

    public interface IProcessListener
    {
        event EventHandler<ProcessStartedEventArgs> ProcessStarted;

        event EventHandler<ProcessStoppedEventArgs> ProcessStopped;

        void Start();

        void Stop();
    }
}