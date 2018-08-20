namespace BMB.Core.Listener
{
    using System;
    using System.Diagnostics;

    public class ProcessStartedEventArgs : EventArgs
    {
        private readonly Process process;

        public ProcessStartedEventArgs(Process process)
        {
            this.process = process;
        }

        public string Name => process.ProcessName;

        public IntPtr WindowHandle => process.MainWindowHandle;
    }
}