using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    class TaskModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool isDone;
        private string text;
        private string comment;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone == value)
                {
                    return;
                }
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public string Comment
        {
            get { return comment; }
            set
            {
                if (comment == value)
                    return;
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
