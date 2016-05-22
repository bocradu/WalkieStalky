using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageCircle.Forms.Plugin.Abstractions;
using WalkieStalky.Model;
using WalkieStalky.Services;
using WalkieStalky.Views;
using Xamarin.Forms;

namespace WalkieStalky.ViewModels
{
    public class TopicsViewModel : BaseViewModel
    {
        public NavigationService NavigationService { get; set; }
        public PersonRecord Model { get; set; }

        public string AddTopicText => "New Topic";

        public ICommand Explore { get; set; }
        public ObservableCollection<Topic> Topics { get; set; }

        public TopicsViewModel(NavigationService navi, PersonRecord model)
        {
            NavigationService = navi;
            Model = model;

            Topics = model.Topics == null
                ? new ObservableCollection<Topic>
                {
                    new Topic(),
                    new Topic(),
                    new Topic(),
                    new Topic(),
                    new Topic(),
                }
                : new ObservableCollection<Topic>(model.Topics.Select(e => new Topic {TopicName = e}));
            Explore = new ExploreCommand();

        }

    }



    public class Topic : BaseViewModel
    {
        private string _topicName;
        public string Image { get; set; }

        public string TopicName
        {
            get { return _topicName; }
            set
            {
                _topicName = value;
                OnPropertyChanged();
            }
        }
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
            var navi = parameter as TopicsViewModel;
            if (navi != null)
            {
                App.MapPageViewModel.TopicsViewModel = navi;
                if (!App.MapPage.Initialized)
                {
                    App.MapPage.Initialize();
                }
                await navi.NavigationService.PushAsync(App.MapPage);
            }
        }
    }
}
