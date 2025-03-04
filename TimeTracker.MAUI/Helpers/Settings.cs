namespace TimeTracker.MAUI.Models
{
    public class Settings
    {
        public string DeviceId { get; set; }
        public DateTime LastSyncTime { get; set; }
        public int SyncIntervalMinutes { get; set; } = 5;
        public bool DarkModeEnabled { get; set; } = false;
        public bool AutoCategorizeEnabled { get; set; } = true;
        public string OneDriveClientId { get; set; }
        public string OneDriveRedirectUri { get; set; }
    }
}
