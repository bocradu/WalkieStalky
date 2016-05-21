using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WalkieStalky.Views
{
    public class NavigationService : INavigation
    {
        public IReadOnlyList<Page> ModalStack
        {
            get
            {
                return Navi.ModalStack;
            }
        }

        public Xamarin.Forms.INavigation Navi { get; internal set; }
        public Page CurrentPage { get; set; }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
              return Navi.NavigationStack;
            }
        }

        public void InsertPageBefore(Page page, Page before)
        {
            Navi.InsertPageBefore(page, before);
        }

        public Task<Page> PopAsync()
        {
            return Navi.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Navi.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return Navi.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navi.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return Navi.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navi.PopToRootAsync(animated);
        }

        public Task PushAsync(Page page)
        {
            return Navi.PushAsync(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return Navi.PushAsync(page);
        }

        public Task PushModalAsync(Page page)
        {
            return Navi.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return Navi.PushModalAsync(page);
        }

        public void RemovePage(Page page)
        {
           Navi.RemovePage(page);
        }
    }
}
