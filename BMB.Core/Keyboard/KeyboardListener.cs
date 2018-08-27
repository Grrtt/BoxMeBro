namespace BMB.Core.Keyboard
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class KeyboardListener : IKeyboardListener
    {
        private User32.LowLevelKeyboardProc callbackFunction;

        private IntPtr KeyboardHookPointer;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Start()
        {
            callbackFunction = OnKeyPressed;
            KeyboardHookPointer = SetKeyboardHook(callbackFunction);
        }

        public void Stop()
        {
            User32.UnhookWindowsHookEx(KeyboardHookPointer);
        }

        private static Keys GetPressedKey(IntPtr lParam)
        {
            int keyCode = Marshal.ReadInt32(lParam);
            return (Keys)keyCode;
        }

        private static IntPtr SetKeyboardHook(User32.LowLevelKeyboardProc callbackFunction)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return User32.SetWindowsHookEx(
                        User32.WH_KEYBOARD_LL,
                        callbackFunction,
                        Kernel32.GetModuleHandle(curModule.ModuleName),
                        0);
                }
            }
        }

        private IntPtr OnKeyPressed(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                Keys pressedKey = GetPressedKey(lParam);
                KeyPressed?.Invoke(this, new KeyPressedEventArgs(pressedKey, wParam));
            }

            return User32.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}