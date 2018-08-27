namespace BMB.Core.Process
{
    using System;
    using System.Management;

    public class ProcessStoppedEventArgs : EventArgs
    {
        public ProcessStoppedEventArgs(EventArrivedEventArgs e)
        {
            ProcessId = Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value);
        }

        public int ProcessId { get; }
    }
}