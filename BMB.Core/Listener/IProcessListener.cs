namespace BMB.Core.Listener
{
    using System;

    public interface IProcessListener
    {
        event EventHandler<ProcessStartedEventArgs> ProcessStartedEvent;

        void Start();

        void Stop();
    }

    public delegate void ProcessStartedEventHandler(object sender, ProcessStartedEventArgs args);
}