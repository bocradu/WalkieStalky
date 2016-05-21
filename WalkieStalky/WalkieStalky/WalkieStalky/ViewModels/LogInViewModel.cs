using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WalkieStalky.Properties;

namespace WalkieStalky.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private bool _stayLoggedIn;

        public LogInViewModel()
        {
            LogInCommand = new LogInCommand();
        }
        public ICommand LogInCommand { get; set; }
        public bool StayLoggedIn
        {
            get { return _stayLoggedIn; }
            set
            {
                _stayLoggedIn = value;
                OnPropertyChanged();
            }
        }
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
            Services.Services.GetInstance().LoginService.LogIn((bool)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

}
