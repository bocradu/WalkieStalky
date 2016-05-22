using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageCircle.Forms.Plugin.Abstractions;
using WalkieStalky.Views;
using Xamarin.Forms;

namespace WalkieStalky.ViewModels
{
    public class TopicsViewModel : BaseViewModel
    {
        public NavigationService NavigationService { get; set; }

        public string AddTopicText => "New Topic";

        public ICommand Explore { get; set; }
        public ObservableCollection<Topic> Topics { get; set; }

        public TopicsViewModel(NavigationService navi)
        {
            NavigationService = navi;

            Topics = new ObservableCollection<Topic>(); 
            Topics.Add(new Topic { TopicName = "Tomato", Image = "tomato.png" });
            Topics.Add(new Topic { TopicName = "Romaine Lettuce", Image = "lettuce.png" });
            Topics.Add(new Topic { TopicName = "Zucchini", Image = "zucchini.png" });

            Explore = new ExploreCommand();
        }

    }

   

    public class Topic
    {
        public string Image { get;  set; }
        public string TopicName { get;  set; }
    }

    internal class ExploreCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var navi = parameter as INavigation;
            if(!App.MapPage.Initialized)
            {
                App.MapPage.Initialize();
            }
            await navi.PushAsync(App.MapPage);
        }
    }
}
