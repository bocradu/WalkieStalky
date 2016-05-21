using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WalkieStalky.ViewModels
{
    public class TopicsViewModel : BaseViewModel
    {
   

        public string AddTopicText => "New Topic";

        public ICommand AddTopicCommand { get; set; }
        public ObservableCollection<Topic> Topics { get; set; }

        public TopicsViewModel()
        {
            Topics = new ObservableCollection<Topic>(); 
            Topics.Add(new Topic { Name = "Tomato", Type = "Fruit", Image = "tomato.png" });
            Topics.Add(new Topic { Name = "Romaine Lettuce", Type = "Vegetable", Image = "lettuce.png" });
            Topics.Add(new Topic { Name = "Zucchini", Type = "Vegetable", Image = "zucchini.png" });

            AddTopicCommand = new AddTopicCommand();

           
        }
    }

    public class Topic
    {
        public string Image { get;  set; }
        public string Name { get;  set; }
        public string Type { get;  set; }
    }

    internal class AddTopicCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
        }
    }
}
