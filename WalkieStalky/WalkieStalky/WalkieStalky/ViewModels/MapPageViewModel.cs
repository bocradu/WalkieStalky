using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WalkieStalky.Views;

namespace WalkieStalky.ViewModels
{
    public class MapPageViewModel : BaseViewModel
    {
        public NavigationService NavigationService { get; set; }

        public MapPageViewModel(NavigationService navi)
        {
            NavigationService = navi;
            TopicsCommand = new TopicsCommand();
        }

        public ICommand TopicsCommand { get; private set; }
    }
}
