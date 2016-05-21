using System;
using System.Threading;
using System.Windows.Input;
using WalkieStalky.Services;
using Xamarin.Forms;

namespace WalkieStalky.ViewModels
{
   public class RestCallViewModel:BaseViewModel
    {
       public RestCallViewModel()
       {
           RestCallsCommand=new RestCallsCommand();
       }
       public ICommand RestCallsCommand { get; set; }
    }

    public class RestCallsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var restModel= parameter as RestCallViewModel;
            var walkiestalkyclient = new walkiestalkyclient();
            await walkiestalkyclient.PutpersonAsync("123", "dad dada da ", new PersonRecord(), new CancellationToken());

        }

        public event EventHandler CanExecuteChanged;
    }
}
