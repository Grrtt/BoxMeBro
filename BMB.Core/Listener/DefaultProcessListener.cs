namespace BMB.Core.Listener
{
    using System;

    public class DefaultProcessListener : IProcessListener
    {
        public event EventHandler<ProcessStartedEventArgs> ProcessStartedEvent;

        public void Start()
        {
            // TODO: To be implemented later.
        }

        public void Stop()
        {
            // TODO: To be implemented later.
        }
    }
}