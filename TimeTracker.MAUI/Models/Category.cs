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
        public List<Category> Subcategories { get; set; } = new List<Category>();
        
        [Ignore] 
        public List<string> Keywords { get; set; } = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Category> GetDefaultCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = "1",
                    Name = "Unterrichtsvorbereitung 📚",
                    IconName = "📚",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "1.1", Name = "Jahresplanung 📅", IconName = "📅" },
                        new Category { Id = "1.2", Name = "Trimesterplanung 📆", IconName = "📆" },
                        new Category { Id = "1.3", Name = "Sequenzplanung 📋", IconName = "📋" },
                        new Category { Id = "1.4", Name = "Stundenplanung 🕒", IconName = "🕒" },
                        new Category { Id = "1.5", Name = "Besondere Events 🎉", IconName = "🎉" }
                    }
                },
                new Category
                {
                    Id = "2",
                    Name = "Besprechungen 🗣️",
                    IconName = "🗣️",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "2.1", Name = "Lehrerkonferenz 🏫", IconName = "🏫" },
                        new Category { Id = "2.2", Name = "Fachkonferenz 📚", IconName = "📚" },
                        new Category { Id = "2.3", Name = "Klassenkonferenz 🏫", IconName = "🏫" },
                        new Category { Id = "2.4", Name = "Elterngespräche 👨‍👩‍👧‍👦", IconName = "👨‍👩‍👧‍👦" },
                        new Category { Id = "2.5", Name = "Gespräch mit Kollegen 🗣️", IconName = "🗣️" }
                    }
                },
                new Category
                {
                    Id = "3",
                    Name = "Verwaltung 🗂️",
                    IconName = "🗂️",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "3.1", Name = "Organisation 📂", IconName = "📂" },
                        new Category { Id = "3.2", Name = "Dokumentation 📝", IconName = "📝" },
                        new Category { Id = "3.3", Name = "Korrektur und Bewertung 📝", IconName = "📝" }
                    }
                },
                new Category
                {
                    Id = "4",
                    Name = "Fortbildung 🎓",
                    IconName = "🎓",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "4.1", Name = "Kurse - Seminare 🏫", IconName = "🏫" },
                        new Category { Id = "4.2", Name = "Selbststudium (berufsbezogen) 📖", IconName = "📖" }
                    }
                },
                new Category
                {
                    Id = "5",
                    Name = "Schülerbetreuung 👩‍🏫",
                    IconName = "👩‍🏫",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "5.1", Name = "Beratung 🗣️", IconName = "🗣️" },
                        new Category { Id = "5.2", Name = "Förderung 📚", IconName = "📚" },
                        new Category { Id = "5.3", Name = "AG - Projekte 🛠️", IconName = "🛠️" }
                    }
                },
                new Category
                {
                    Id = "6",
                    Name = "Soziales 🤝",
                    IconName = "🤝",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "6.1", Name = "Jacqueline 👩", IconName = "👩" },
                        new Category { Id = "6.2", Name = "Simon 👨", IconName = "👨" },
                        new Category { Id = "6.3", Name = "Fabian 👦", IconName = "👦" },
                        new Category { Id = "6.4", Name = "Elternbeirat 👨‍👩‍👧‍👦", IconName = "👨‍👩‍👧‍👦" },
                        new Category { Id = "6.5", Name = "Freunde 👥", IconName = "👥" }
                    }
                },
                new Category
                {
                    Id = "7",
                    Name = "Persönliche Zeit 🕒",
                    IconName = "🕒",
                    Subcategories = new List<Category>
                    {
                        new Category { Id = "7.1", Name = "Unproduktive Zeit 💤", IconName = "💤" },
                        new Category { Id = "7.2", Name = "Haushalt 🏠", IconName = "🏠" },
                        new Category { Id = "7.3", Name = "Sport und Gesundheit 🏋️‍♂️", IconName = "🏋️‍♂️" },
                        new Category { Id = "7.4", Name = "Buch lesen 📖", IconName = "📖" },
                        new Category { Id = "7.5", Name = "App Programmierung 💻", IconName = "💻" }
                    }
                }
            };
        }
    }
}
