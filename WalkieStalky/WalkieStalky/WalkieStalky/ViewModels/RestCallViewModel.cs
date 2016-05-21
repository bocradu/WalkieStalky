using System;
using System.Windows.Input;
using WalkieStalky.Services;

namespace WalkieStalky.ViewModels
{
    public class RestCallViewModel : BaseViewModel
    {
        public RestCallViewModel()
        {
            PostRestCallCommand = new PostRestCallCommand();
            GetRestCallCommand = new GetRestCallCommand();
        }
        public ICommand PostRestCallCommand { get; set; }
        public ICommand GetRestCallCommand { get; set; }
    }

    public class PostRestCallCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            var restModel = parameter as RestCallViewModel;
            var walkiestalkyclient = new WalkieTalkyClient();
            walkiestalkyclient.CreatePostRequest();

        }

        public event EventHandler CanExecuteChanged;
    }

    public class GetRestCallCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var restModel = parameter as RestCallViewModel;
            //  var walkiestalkyclient = new mustBedeleted();
            var walkiestalkyclient = new WalkieTalkyClient();
            walkiestalkyclient.CreateGetRequest();
            //await walkiestalkyclient.PutpersonAsync("123", "dad dada da ", new PersonRecord(), new CancellationToken());

        }

        public event EventHandler CanExecuteChanged;
    }
}
