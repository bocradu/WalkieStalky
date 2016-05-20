using Xamarin.Auth;

namespace WalkieStalky.Services
{
    public class Services
    {
        public static Services GetInstance()
        {
            return _servicesInstance;
        }
        public static void SetInstance(Services services)
        {
            _servicesInstance = services;
        }

        private static Services _servicesInstance;

        public ILoginService LoginService { get; set; }
    }

    public interface ILoginService
    {
        void LogIn();
        event OnLoginEvent OnLogin;
    }

    public delegate void OnLoginEvent(object sender, OnLoginEventArgs args);

    public class OnLoginEventArgs
    {
        public Account Account { get; set; }
    }
}
