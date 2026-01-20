using MAUILinearEquation.ViewModel;

namespace MAUILinearEquation
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LinearEquationViewModel();
        }
    }
}
