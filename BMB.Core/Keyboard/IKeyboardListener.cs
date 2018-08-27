namespace BMB.Core.Keyboard
{
    using System;

    public interface IKeyboardListener
    {
        event EventHandler<KeyPressedEventArgs> KeyPressed;

        void Start();

        void Stop();
    }
}