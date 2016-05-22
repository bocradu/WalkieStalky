using System;
using System.Windows.Input;
using WalkieStalky.Services;

namespace WalkieStalky.ViewModels
{
    public class RestCallViewModel : BaseViewModel
    {
        public RestCallViewModel()
        {
            PutRestCallCommand = new PutRestCallCommand();
            GetRestCallCommand = new GetRestCallCommand();
        }
        public ICommand PutRestCallCommand { get; set; }
        public ICommand GetRestCallCommand { get; set; }
    }

    public class PutRestCallCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

           // var restModel = parameter as RestCallViewModel;
            var walkiestalkyclient = new WalkieTalkyClient();
            string fakeToken = "0de77c08b76406e9eb6703c0663061e9f3445054d17fc1de490ff4b2da0f8ef7";
            var personList=  walkiestalkyclient.CreatePutRequest(fakeToken);

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
            //var restModel = parameter as RestCallViewModel;
            var walkiestalkyclient = new WalkieTalkyClient();
            string fakeToken = "iulian";
            var personRecord= walkiestalkyclient.CreateGetRequest(fakeToken);
        }

        public event EventHandler CanExecuteChanged;
    }
}
