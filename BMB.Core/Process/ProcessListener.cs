namespace BMB.Core.Process
{
    using System;
    using System.Management;
    using System.Threading;

    public class ProcessListener : IProcessListener
    {
        private const string ProcessStartedWqlQuery = "SELECT * FROM Win32_ProcessStartTrace";

        private const string ProcessStoppedWqlQuery = "SELECT * FROM Win32_ProcessStopTrace";

        private ManagementEventWatcher processStartedWatcher;

        private ManagementEventWatcher processStoppedWatcher;

        public event EventHandler<ProcessStartedEventArgs> ProcessStarted;

        public event EventHandler<ProcessStoppedEventArgs> ProcessStopped;

        public void Start()
        {
            processStartedWatcher = CreateProcessStartedEventWatcher();
            processStartedWatcher.Start();

            processStoppedWatcher = CreateProcessStoppedEventWatcher();
            processStoppedWatcher.Start();
        }

        public void Stop()
        {
            processStartedWatcher.Stop();
            processStoppedWatcher.Stop();
        }

        private static ManagementEventWatcher CreateProcessWatcher(WqlEventQuery processQuery)
        {
            return new ManagementEventWatcher(processQuery);
        }

        private static WqlEventQuery CreateWqlEventQuery(string query)
        {
            return new WqlEventQuery(query);
        }

        private ManagementEventWatcher CreateProcessStartedEventWatcher()
        {
            WqlEventQuery processStartedWqlQuery = CreateProcessStartedWqlQuery();
            processStartedWatcher = CreateProcessWatcher(processStartedWqlQuery);
            processStartedWatcher.EventArrived += OnProcessStartedStarted;

            return processStartedWatcher;
        }

        private WqlEventQuery CreateProcessStartedWqlQuery()
        {
            return CreateWqlEventQuery(ProcessStartedWqlQuery);
        }

        private ManagementEventWatcher CreateProcessStoppedEventWatcher()
        {
            WqlEventQuery processStoppedWqlQuery = CreateProcessStoppedWqlQuery();
            processStoppedWatcher = CreateProcessWatcher(processStoppedWqlQuery);
            processStoppedWatcher.EventArrived += OnProcessStopped;

            return processStoppedWatcher;
        }

        private WqlEventQuery CreateProcessStoppedWqlQuery()
        {
            return CreateWqlEventQuery(ProcessStoppedWqlQuery);
        }

        private void OnProcessStartedStarted(object sender, EventArrivedEventArgs e)
        {
            Thread.Sleep(1000);
            Console.WriteLine("----- Process Started -----");
            ProcessStarted?.Invoke(this, new ProcessStartedEventArgs(e));
        }

        private void OnProcessStopped(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("----- Process Stopped -----");
            ProcessStopped?.Invoke(this, new ProcessStoppedEventArgs(e));
        }
    }
}