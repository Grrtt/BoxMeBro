namespace BMB.Core.BoxManagement
{
    using System.Collections.Generic;

    using Process;

    public interface IBoxRepository
    {
        void AddBoxToCache(ProcessStartedEventArgs eventArgs);

        IEnumerable<WindowBox> GetAll();

        void Remove(int processId);
    }
}