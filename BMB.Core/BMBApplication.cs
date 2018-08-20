namespace BMB.Core
{
    using BoxManagement;

    using Listener;

    public class BMBApplication
    {
        private readonly IProcessHandler processHandler;

        private readonly IProcessListener processListener;

        public BMBApplication(IProcessListener processListener, IProcessHandler processHandler)
        {
            this.processListener = processListener;
            this.processHandler = processHandler;
        }

        public void Start()
        {
            StartProcessListener();
        }

        public void Stop()
        {
            processListener.Stop();
        }

        private void HandleProcess(object sender, ProcessStartedEventArgs eventArgs)
        {
            processHandler.HandleProcess(eventArgs);
        }

        private void StartProcessListener()
        {
            processListener.Start();
            processListener.ProcessStartedEvent += HandleProcess;
        }
    }
}