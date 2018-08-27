namespace BMB.Core.Keyboard
{
    using System;

    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(Keys pressedKey, IntPtr keyEvent)
        {
            PressedKey = pressedKey;
            KeyEvent = keyEvent;
        }

        public IntPtr KeyEvent { get; }

        public Keys PressedKey { get; }
    }
}