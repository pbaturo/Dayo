using Dayo.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Dayo
{
    public class MainWindowViewModel : INotifyPropertyChanged 
    {
        private readonly Store store;
        public MainWindowViewModel(Store store)
        {
            this.store = store;
            note = new Note();
        }

        private Note note;
        public string Title
        {
            get { return note.Title; }
            set
            {
                if(note.Title != value)
                {
                    note.Title = value;
                    OnPropertyChange(nameof(Title));
                }
            }
        }

        public string Content
        {
            get { return note.Content; }
            set
            {
                if (note.Content != value)
                {
                    note.Content = value;
                    OnPropertyChange(nameof(Content));
                }
            }
        }

        public int CaretIndex { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand commandAddCheckBox;
        public ICommand CommandAddCheckBox 
        {
            get
            {
                return commandAddCheckBox ?? (commandAddCheckBox = new RelayCommand(
                    x =>
                    {
                        AddCheckBox(this.Content);
                    }));
            }
        }

        public void AddCheckBox(string content)
        {
            this.Content = content.Insert(0, "\u2610");
        }

        private ICommand commandClose;
        public ICommand CommandClose
        {
            get
            {
                return commandClose ?? (commandClose = new RelayCommand(
                    x =>
                    {
                        store.StoreMemoryList(this.Content);
                        System.Windows.Application.Current.Shutdown();
                    }));
            }
        }
    }
}
