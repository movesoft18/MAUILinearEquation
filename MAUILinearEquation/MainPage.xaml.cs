namespace MAUILinearEquation
{
    public partial class MainPage : ContentPage
    {
        public bool isAValid 
        { 
            get 
            {
                return Double.TryParse(AEntry.Text, out double a);
            }
        }
        public bool isBValid 
        {
            get
            {
                return Double.TryParse(BEntry.Text, out double b);
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSolveButtonClicked(object sender, EventArgs e)
        {
            Double.TryParse(AEntry.Text, out double a);
            Double.TryParse(BEntry.Text, out double b);
            var (result, roots) = Classes.LinearEquationSolver.Solve(a, b);
            switch (roots)
            {
                case 0:
                    AnswerLabel.Text = "Нет корней";
                    break;
                case 1:
                    AnswerLabel.Text = result.ToString();
                    break;
                case 2:
                    AnswerLabel.Text = "Бесконечное множество корней";
                    break;
            }
        }

        private void AEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SolveButton.IsEnabled = isAValid && isBValid;
            if (SolveButton.IsEnabled)
            {
                SolveButton.BackgroundColor = Colors.BlueViolet;
            }
            else
            {
                SolveButton.BackgroundColor = Colors.Gray;
            }
        }

        private void AEntry_Completed(object sender, EventArgs e)
        {
            var a  = 3 + 4;
        }
    }
}
