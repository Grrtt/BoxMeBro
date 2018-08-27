namespace BMB.Core
{
    using Keyboard;

    using Process;

    public class BMBApplication
    {
        private readonly IKeyboardHandler keyboardHandler;

        private readonly IKeyboardListener keyboardListener;

        private readonly IProcessHandler processHandler;

        private readonly IProcessListener processListener;

        public BMBApplication(
            IProcessListener processListener,
            IProcessHandler processHandler,
            IKeyboardListener keyboardListener,
            IKeyboardHandler keyboardHandler)
        {
            this.processListener = processListener;
            this.processHandler = processHandler;
            this.keyboardListener = keyboardListener;
            this.keyboardHandler = keyboardHandler;
        }

        public void Start()
        {
            StartProcessListener();
            StartKeyboardListener();
        }

        public void Stop()
        {
            StopProcessListener();
            StopKeyboardListener();
        }

        private void HandleKeyPress(object sender, KeyPressedEventArgs eventArgs)
        {
            keyboardHandler.HandleKeyPress(eventArgs);
        }

        private void HandleProcess(object sender, ProcessStartedEventArgs eventArgs)
        {
            processHandler.HandleProcess(eventArgs);
        }

        private void HandleProcess(object sender, ProcessStoppedEventArgs eventArgs)
        {
            processHandler.HandleProcess(eventArgs);
        }

        private void StartKeyboardListener()
        {
            keyboardListener.KeyPressed += HandleKeyPress;
            keyboardListener.Start();
        }

        private void StartProcessListener()
        {
            processListener.ProcessStarted += HandleProcess;
            processListener.ProcessStopped += HandleProcess;
            processListener.Start();
        }

        private void StopKeyboardListener()
        {
            keyboardListener.Stop();
        }

        private void StopProcessListener()
        {
            processListener.Stop();
        }
    }
}