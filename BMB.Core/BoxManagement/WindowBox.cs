namespace BMB.Core.BoxManagement
{
    using System;

    public class WindowBox
    {
        public WindowBox(IntPtr mainWindowHandle, IntPtr handle, int processId)
        {
            MainWindowHandle = mainWindowHandle;
            Handle = handle;
            ProcessId = processId;
        }

        public IntPtr Handle { get; }

        public IntPtr MainWindowHandle { get; }

        public int ProcessId { get; }
    }
}