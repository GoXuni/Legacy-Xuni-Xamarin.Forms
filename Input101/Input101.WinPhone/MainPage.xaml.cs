using Xamarin.Forms.Platform.WinPhone;
using Xuni.Forms.Input.Platform.WinPhone;
using Xuni.Forms.Calendar.Platform.WinPhone;
namespace Input101.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            XuniInputRenderer.Init();
            XuniCalendarRenderer.Init();
            InitializeComponent();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new Input101.App()); 
        }
    }
}