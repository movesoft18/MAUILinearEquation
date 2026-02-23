using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;


namespace MAUILinearEquation.ViewModel
{
    public partial class LinearEquationViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SolveCommand))]
        [NotifyPropertyChangedFor(nameof(CanSolve))]
        private string _coefA;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SolveCommand))]
        [NotifyPropertyChangedFor(nameof(CanSolve))]
        private string _coefB;

        [ObservableProperty]
        private string _result;

        [ObservableProperty]
        private bool _isAValid;

        [ObservableProperty]
        private bool _isBValid;

        [ObservableProperty]
        private List<string> _isAAA = new List<string> { "invalidValue"};

        public bool CanSolve => CanPressSolveButton();

        [RelayCommand(CanExecute = nameof(CanPressSolveButton))]
        private void Solve()
        {
            Double.TryParse(CoefA, out double a);
            Double.TryParse(CoefB, out double b);
            var (root, count) = Classes.LinearEquationSolver.Solve(a, b);
            switch (count)
            {
                case 0:
                    Result = $"Корней нет";
                    break;
                case 1:
                    Result = $"x = {root.ToString()}";
                    break;
                case 2:
                    Result = $"Бесконечное множество решений";
                    break;
                default:
                    Result = $"ОШИБКА";
                    break;

            }
        }

        private bool CanPressSolveButton()
        {
            IsAValid = Double.TryParse(CoefA, out _);
            IsBValid = Double.TryParse(CoefB, out _);
            return IsAValid && IsBValid;
        }

    }
}
