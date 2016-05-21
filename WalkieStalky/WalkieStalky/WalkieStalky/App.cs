using System;
using WalkieStalky.Services;
using WalkieStalky.Views;
using Xamarin.Auth;
using Xamarin.Forms;

namespace WalkieStalky
{
    public class App : Application
    {
        private const string AppName = "WalkieStalky";

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
            HttpService.SendAuthenticationCredentials(args.Account);
            Services.Services.GetInstance().AccountService.SaveAccount(args.Account, AppName);
           MainPage=new MapPage();
        }

        protected override void OnStart()
        {
            var account=Services.Services.GetInstance().AccountService.GetAccountFor(AppName);
            if (account != null)
            {
                MainPage=new MapPage();
            }
           
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
