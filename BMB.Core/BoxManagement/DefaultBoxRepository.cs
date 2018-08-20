namespace BMB.Core.BoxManagement
{
    using System.Collections.Generic;
    using System.Linq;

    using Listener;

    public class DefaultBoxRepository : IBoxRepository
    {
        private readonly List<WindowBox> cache;

        public DefaultBoxRepository()
        {
            cache = new List<WindowBox>();
        }

        public void AddBoxForProcess(ProcessStartedEventArgs eventArgs)
        {
            cache.Add(new WindowBox(eventArgs.WindowHandle));
        }

        public IEnumerable<WindowBox> GetAll()
        {
            return cache.AsEnumerable();
        }
    }
}