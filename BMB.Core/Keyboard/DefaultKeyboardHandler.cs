namespace BMB.Core.Keyboard
{
    using System;

    using BoxManagement;

    public class DefaultKeyboardHandler : IKeyboardHandler
    {
        private readonly IBoxRepository boxRepository;

        public DefaultKeyboardHandler(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
        }

        public void HandleKeyPress(KeyPressedEventArgs eventArgs)
        {
            foreach (WindowBox box in boxRepository.GetAll())
            {
                if()
                Console.WriteLine(
                    $"Sending {eventArgs.PressedKey}({(IntPtr)eventArgs.PressedKey}, {(KeyEvent)eventArgs.KeyEvent}) to {box.MainWindowHandle}");

                User32.SendMessage(
                    box.MainWindowHandle,
                    (int)eventArgs.KeyEvent,
                    (IntPtr)eventArgs.PressedKey,
                    IntPtr.Zero);
            }
        }
    }
}