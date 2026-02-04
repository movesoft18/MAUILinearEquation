using System.Runtime.CompilerServices;

namespace MAUILinearEquation
{
    public partial class MainPage : ContentPage
    {
        public bool IsAValid
        {
            get
            {
                return Double.TryParse(
                    AEntry.Text,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double a);
            }
        }
        public bool IsBValid
        {
            get
            {
                return Double.TryParse(
                    BEntry.Text,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double a);
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSolveButtonClicked(object sender, EventArgs e)
        {
            Double.TryParse(
                    AEntry.Text,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double a);
            Double.TryParse(
                    BEntry.Text,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double b);
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

        private void EnableOrDisableSolveButton()
        {
            SolveButton.IsEnabled = IsAValid && IsBValid;
            if (SolveButton.IsEnabled)
            {
                SolveButton.BackgroundColor = Colors.BlueViolet;
            }
            else
            {
                SolveButton.BackgroundColor = Colors.Gray;
            }
        }

        private void MarkError(Entry entry, bool isValid)
        {
            if (!isValid && !string.IsNullOrEmpty(entry.Text))
            {
                entry.BackgroundColor = Colors.Pink;
            }
            else
            {
                entry.BackgroundColor = Colors.White;
            }
        }

        private void AEntry_TextChanged(object sender, EventArgs e)
        {
            EnableOrDisableSolveButton();
            if (sender is Entry entry)
            {
                MarkError(entry, IsAValid);
            }
        }

        private void BEntry_TextChanged(object sender, EventArgs e)
        {
            EnableOrDisableSolveButton();
            if (sender is Entry entry)
            {
                MarkError(entry, IsBValid);
            }
        }
    }
}
