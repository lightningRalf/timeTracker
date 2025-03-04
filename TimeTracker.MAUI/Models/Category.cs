using SQLite;
using System.Collections.Generic;
using System.ComponentModel;

namespace TimeTracker.MAUI.Models
{
    public class Category : INotifyPropertyChanged
    {
        [PrimaryKey]
        public string Id { get; set; }
        
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        
        public string Color { get; set; }
        
        public string IconName { get; set; }
        
        public string ParentId { get; set; }
        
        [Ignore]
        public List Subcategories { get; set; } = new List();
        
        [Ignore] 
        public List Keywords { get; set; } = new List();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
