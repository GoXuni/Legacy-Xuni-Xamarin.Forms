namespace FlexGrid101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            if (Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.Windows)
                Resources["TitleVisible"] = false;
            MainPage = new Xamarin.Forms.NavigationPage(new FlexGridSamples());
        }

        protected override void OnStart()
        {
            Xuni.Forms.Core.LicenseManager.Key = License.Key;
        }
    }
}
