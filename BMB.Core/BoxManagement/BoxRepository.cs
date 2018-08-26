namespace BMB.Core.BoxManagement
{
    using System.Collections.Generic;
    using System.Linq;

    using Listener;

    public class BoxRepository : IBoxRepository
    {
        private readonly ICollection<WindowBox> windowBoxCache;

        public BoxRepository(ICollection<WindowBox> windowBoxCache)
        {
            this.windowBoxCache = windowBoxCache;
        }

        public void AddBoxToCache(ProcessStartedEventArgs eventArgs)
        {
            windowBoxCache.Add(new WindowBox(eventArgs.WindowHandle));
        }

        public IEnumerable<WindowBox> GetAll()
        {
            return windowBoxCache.AsEnumerable();
        }
    }
}