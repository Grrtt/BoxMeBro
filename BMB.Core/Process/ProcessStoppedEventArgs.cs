namespace BMB.Core.Process
{
    using System;
    using System.Management;

    public class ProcessStoppedEventArgs : EventArgs
    {
        public ProcessStoppedEventArgs(EventArrivedEventArgs eventArgs)
        {
            ProcessId = Convert.ToInt32(eventArgs.NewEvent.Properties["ProcessId"].Value);
        }

        public int ProcessId { get; }
    }
}