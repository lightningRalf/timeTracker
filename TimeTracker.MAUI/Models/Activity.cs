using SQLite;
using System;
using System.ComponentModel;

namespace TimeTracker.MAUI.Models
{
    public class Activity : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string ServerId { get; set; } // For sync/comparison

        private string _activity;
        public string ActivityName
        {
            get => _activity;
            set
            {
                if (_activity != value)
                {
                    _activity = value;
                    OnPropertyChanged(nameof(ActivityName));
                }
            }
        }

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public string CategoryDisplay { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime? EndTime { get; set; }
        
        public int Duration { get; set; }
        
        public DateTime ModifiedTime { get; set; }
        
        public string DeviceId { get; set; }
        
        // Helper property for UI
        public bool IsCompleted => EndTime.HasValue;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
