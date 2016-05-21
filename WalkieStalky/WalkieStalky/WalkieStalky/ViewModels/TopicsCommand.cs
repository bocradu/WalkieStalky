using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WalkieStalky.Views;
using Xamarin.Forms;
namespace WalkieStalky.ViewModels
{
    internal class TopicsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var navi = parameter as INavigation;
            await navi.PopAsync();
        }
    }
}