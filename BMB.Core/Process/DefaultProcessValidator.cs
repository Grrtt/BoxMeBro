namespace BMB.Core.Process
{
    using System;

    public class DefaultProcessValidator : IProcessValidator
    {
        public bool ValidateProcess(ProcessStartedEventArgs eventArgs)
        {
            // TODO: Consider making Notepad.exe a constant pulled from configuration.
            return string.Equals(eventArgs.Name, "wow", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}