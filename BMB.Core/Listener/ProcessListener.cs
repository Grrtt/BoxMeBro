namespace BMB.Core.Listener
{
    using System;
    using System.Diagnostics;
    using System.Management;

    public class ProcessListener : IProcessListener
    {
        private const string AllProcessesWqlQuery = "SELECT * FROM Win32_ProcessStartTrace";

        private ManagementEventWatcher processWatcher;

        ~ProcessListener()
        {
            processWatcher = null;
        }

        public event EventHandler<ProcessStartedEventArgs> ProcessStartedEvent;

        public void Start()
        {
            processWatcher = CreateProcessEventWatcher();
            processWatcher.EventArrived += ProcessStarted;
            processWatcher.Start();
        }

        public void Stop()
        {
            processWatcher.Stop();
        }

        private ManagementEventWatcher CreateProcessEventWatcher()
        {
            WqlEventQuery processQuery = GetWqlEventQuery();
            return new ManagementEventWatcher(processQuery);
        }

        private Process GetProcess(EventArrivedEventArgs eventArgs)
        {
            int processId = (int)eventArgs.NewEvent.Properties["ProcessID"].Value;
            return Process.GetProcessById(processId);
        }

        private WqlEventQuery GetWqlEventQuery()
        {
            return new WqlEventQuery(AllProcessesWqlQuery);
        }

        private void ProcessStarted(object sender, EventArrivedEventArgs e)
        {
            Process process = GetProcess(e);
            ProcessStartedEvent?.Invoke(this, new ProcessStartedEventArgs(process));
        }
    }
}