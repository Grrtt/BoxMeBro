namespace BMB.Core.BoxManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Process;

    public class BoxRepository : IBoxRepository
    {
        private readonly ICollection<WindowBox> windowBoxCache;

        public BoxRepository()
        {
            windowBoxCache = new List<WindowBox>();
        }

        public void AddBoxToCache(ProcessStartedEventArgs eventArgs)
        {
            LogProcess(eventArgs);
            windowBoxCache.Add(new WindowBox(eventArgs.MainWindowHandle, eventArgs.Handle, eventArgs.ProcessId));
        }

        public IEnumerable<WindowBox> GetAll()
        {
            return windowBoxCache.AsEnumerable();
        }

        public void Remove(int processId)
        {
            Console.WriteLine($"Removing {processId} from cache.");
            WindowBox windowBox = windowBoxCache.First(box => box.ProcessId == processId);
            windowBoxCache.Remove(windowBox);
        }

        private void LogProcess(ProcessStartedEventArgs eventArgs)
        {
            Console.WriteLine("----- Adding Process to Cache -----");
            Console.WriteLine($"Process Name: {eventArgs.Name}");
            Console.WriteLine($"Process ID: {eventArgs.ProcessId}");
            Console.WriteLine($"M.W. Handle: {eventArgs.MainWindowHandle}");
            Console.WriteLine($"Handle: {eventArgs.Handle}");
        }
    }
}