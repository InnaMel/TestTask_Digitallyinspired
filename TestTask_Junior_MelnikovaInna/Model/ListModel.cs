using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Junior_MelnikovaInna.Model
{
    public class ListModel : INotifyPropertyChanged
    {
        public ListModel()
        {
            listTasks = new ObservableCollection<string> { "Task3", "Task4", "Task5" };
        }

        /// <summary>
        /// implementation Interface "INotifyPropertyChanged"
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private ObservableCollection<string> listTasks;

        public ObservableCollection<string> ListTasks
        {
            get { return listTasks; }
            set
            {
                if (listTasks != value)
                {
                    listTasks = value;
                    RaisePropertyChanged("ListTasks");
                }
            }
        }
    }
}