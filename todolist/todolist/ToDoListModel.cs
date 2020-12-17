using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using todolist.Annotations;

namespace todolist
{
   public class ToDoListModel : INotifyPropertyChanged
    {
        public ToDoListModel()
        {
            ToDoItems = new ObservableCollection<object>();
        }

        public void AddValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }
            ToDoItems.Add(value);
        }

        public void RemoveValue(object str)
        {
           ToDoItems.Remove(str);
        }

        public ObservableCollection<object> ToDoItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
