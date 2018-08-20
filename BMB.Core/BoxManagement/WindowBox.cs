namespace BMB.Core.BoxManagement
{
    using System;

    public class WindowBox
    {
        public WindowBox(IntPtr windowHandle)
        {
            WindowHandle = windowHandle;
        }

        public IntPtr WindowHandle { get; }
    }
}