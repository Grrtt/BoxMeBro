namespace BMB.Core.Keyboard
{
    public interface IKeyboardHandler
    {
        void HandleKeyPress(KeyPressedEventArgs eventArgs);
    }
}