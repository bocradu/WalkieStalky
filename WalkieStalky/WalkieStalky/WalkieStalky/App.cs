using System;
using WalkieStalky.Model;
using WalkieStalky.Services;
using WalkieStalky.ViewModels;
using WalkieStalky.Views;
using Xamarin.Auth;
using Xamarin.Forms;

namespace WalkieStalky
{
    public class App : Application
    {
        public const string AppName = "WalkieStalky";
        public static MapPageViewModel MapPageViewModel { get; set; }
        public static TopicsViewModel TopicsViewModel { get; set; }
        public static MapPage MapPage { get; private set; }
        public static Page TopicsPage { get; private set; }

        public App(Services.Services services)
        {
            services.LoginService.OnLogin += OnLogin;
            services.LoginService.OnFail += LoginServiceOnOnFail;
            Services.Services.SetInstance(services);
            HttpService=new HttpService();
            MainPage = new LoginPage();

        }

        public IHttpService HttpService { get; set; }
        private void LoginServiceOnOnFail(object sender, OnFailEventArgs args)
        {
            
        }

        private void OnLogin(object sender, OnLoginEventArgs args)
        {
            if(args.Account==null)
            {
                return;
            }
            if (args.StayLoggedIn)
            {
                Services.Services.GetInstance().AccountService.SaveAccount(args.Account, AppName);
            }
            HttpService.SendAuthenticationCredentials(args.Account);
            var httpClient = new WalkieTalkyClient();
            var model = httpClient.CreateGetRequest(args.Account.Properties["access_token"]);
            StartNavigationService(model);
        }

        protected override void OnStart()
        {
            var account=Services.Services.GetInstance().AccountService.GetAccountFor(AppName);
            if (account != null)
            {
                var httpClient=new WalkieTalkyClient();
                var model=httpClient.CreateGetRequest(account.Properties["access_token"]);
                StartNavigationService(model);
            }
           
        }

        private void StartNavigationService(PersonRecord model)
        {
            NavigationService navi = new NavigationService();

            TopicsViewModel = new TopicsViewModel(navi, model);
            MapPageViewModel = new MapPageViewModel(navi, model);

            TopicsPage = new NavigationPage(new TopicsPage());
            MapPage = new MapPage();

            navi.Navi = TopicsPage.Navigation;
            navi.CurrentPage = TopicsPage;
            MainPage = TopicsPage;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }

    public interface IHttpService
    {
        void SendAuthenticationCredentials(Account account);
    }

    public class HttpService:IHttpService
    {
        public void SendAuthenticationCredentials(Account account)
        {
            
        }
    }
}
