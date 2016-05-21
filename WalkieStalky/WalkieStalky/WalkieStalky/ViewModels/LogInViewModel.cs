using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WalkieStalky.Properties;

namespace WalkieStalky.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public LogInViewModel()
        {
            LogInCommand = new LogInCommand();
        }
        public ICommand LogInCommand { get; set; }

        public string LogInText => "Log in with Facebook";
    }

    public class LogInCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Services.Services.GetInstance().LoginService.LogIn();
        }

        public event EventHandler CanExecuteChanged;
    }

}
