﻿using NzbDrone.Core.ThingiProvider;

namespace NzbDrone.Core.Notifications
{
    public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImplementationName { get; set; }
        public string Link { get; set; }
        public bool OnGrab { get; set; }
        public bool OnDownload { get; set; }
        public IProviderConfig Settings { get; set; }
        public INotification Instance { get; set; }
        public string Implementation { get; set; }
    }
}
