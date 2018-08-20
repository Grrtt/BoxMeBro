namespace BMB.Core.BoxManagement
{
    using System;

    using Listener;

    public class DefaultProcessValidator : IProcessValidator
    {
        public bool ValidateProcess(ProcessStartedEventArgs eventArgs)
        {
            return string.Equals(eventArgs.Name, "Notepad.exe", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}