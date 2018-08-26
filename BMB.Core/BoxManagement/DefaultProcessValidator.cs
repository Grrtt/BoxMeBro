namespace BMB.Core.BoxManagement
{
    using System;

    using Listener;

    public class DefaultProcessValidator : IProcessValidator
    {
        public bool ValidateProcess(ProcessStartedEventArgs eventArgs)
        {
            // TODO: Consider making Notepad.exe a constant pulled from configuration.
            return string.Equals(eventArgs.Name, "Notepad.exe", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}