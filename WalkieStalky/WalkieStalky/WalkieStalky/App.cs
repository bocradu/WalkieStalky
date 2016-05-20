using System;
using WalkieStalky.Services;
using WalkieStalky.Views;
using Xamarin.Forms;

namespace WalkieStalky
{
    public interface IAllert
    {
        void Throw();
    }
    public class App : Application
    {
        public App(Services.Services services)
        {
            services.LoginService.OnLogin += OnLogin;
            services.LoginService.OnFail += LoginServiceOnOnFail;
            Services.Services.SetInstance(services);
            
            MainPage = new LoginPage();
        }

        private void LoginServiceOnOnFail(object sender, OnFailEventArgs args)
        {
            
        }

        private void OnLogin(object sender, OnLoginEventArgs args)
        {
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
           // _alertService.Throw();
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
}
