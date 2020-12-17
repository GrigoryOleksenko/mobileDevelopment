using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using todolist.Annotations;
using Xamarin.Forms;

namespace todolist
{
    public class ToDoListViewModel : INotifyPropertyChanged
    {
        readonly ToDoListModel _model = new ToDoListModel();

        public ToDoListViewModel()
        {
            _model.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };

            Delete = new Command<object>(i =>
            {
                _model.RemoveValue(i);
            });

            Add = new Command<string>(str => {
               _model.AddValue(str);
               InputText = string.Empty;
               OnPropertyChanged("InputText");
               Console.Write(MyValues);
            });
            MyValues.Add("qwdqwd");
        }

        public Command<string> Add { get; set; }
        public Command<object> Delete { get; set; }
        public ObservableCollection<object> MyValues => _model.ToDoItems;
        public string InputText { get; set; }
        public object ItemSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
