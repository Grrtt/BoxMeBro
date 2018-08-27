namespace BMB.Core.Keyboard
{
    using System;
    using System.Linq;

    using BoxManagement;

    public class KeyboardHandler : IKeyboardHandler
    {
        private readonly IBoxRepository boxRepository;

        public KeyboardHandler(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
        }

        public void HandleKeyPress(KeyPressedEventArgs eventArgs)
        {
            WindowBox[] windowBoxes = boxRepository.GetAll().ToArray();
            foreach (WindowBox box in windowBoxes)
            {
                if (IsActiveFocus(box))
                {
                    continue;
                }

                if (IsFocusInCache(windowBoxes))
                {
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

        private static bool IsActiveFocus(WindowBox box)
        {
            return box.MainWindowHandle == User32.GetForegroundWindow();
        }

        private bool IsFocusInCache(WindowBox[] windowBoxes)
        {
            return windowBoxes.Any(x => x.MainWindowHandle == User32.GetForegroundWindow());
        }
    }
}