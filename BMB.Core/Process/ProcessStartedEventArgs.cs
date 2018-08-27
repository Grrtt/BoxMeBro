namespace BMB.Core.Process
{
    using System;
    using System.Diagnostics;
    using System.Management;

    public class ProcessStartedEventArgs : EventArgs
    {
        private readonly Process process;

        public ProcessStartedEventArgs(EventArrivedEventArgs eventArgs)
        {
            process = GetProcess(eventArgs);
        }

        public IntPtr Handle => process.Handle;

        public IntPtr MainWindowHandle => process.MainWindowHandle;

        public string Name => process.ProcessName;

        public int ProcessId => process.Id;

        private Process GetProcess(EventArrivedEventArgs eventArrivedEventArgs)
        {
            uint processId = (uint)eventArrivedEventArgs.NewEvent.Properties["ProcessId"].Value;
            return Process.GetProcessById((int)processId);
        }
    }
}