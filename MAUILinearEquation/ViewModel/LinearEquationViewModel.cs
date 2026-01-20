using MAUILinearEquation.Models;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace MAUILinearEquation.ViewModel
{
    public class LinearEquationViewModel : INotifyPropertyChanged
    {
        LinearEquationData data = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SolveCommand { get; set; }

        public string CoefA
        {
            get => data.CoefA;
            set
            {
                if (data.CoefA != value)
                {
                    data.CoefA = value;
                    OnPropertyChanged();
                    ValidateA();
                }
            }
        }
        public string CoefB
        {
            get => data.CoefB;
            set
            {
                if (data.CoefB != value)
                {
                    data.CoefB = value;
                    OnPropertyChanged();
                    ValidateB();
                }
            }
        }

        public string Result
        {
            get => data.Result;
            set
            {
                if (data.Result != value)
                {

                    data.Result = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsAValid
        {
            get => data.IsValidA;
            set
            {
                if (data.IsValidA != value)
                {
                    data.IsValidA = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBValid
        {
            get => data.IsValidB;
            set
            {
                if (data.IsValidB != value)
                {
                    data.IsValidB = value;
                    OnPropertyChanged();
                }
            }
        }

        public LinearEquationViewModel()
        {
            SolveCommand = new Command(() =>
            {
                double a, b;
                if (
                    Double.TryParse(CoefA, CultureInfo.InvariantCulture, out a) &&
                    Double.TryParse(CoefB, CultureInfo.InvariantCulture, out b))
                {
                    // Логика решения линейного уравнения
                    if (a == 0)
                    {
                        if (b == 0)
                            Result = "Бесконечное множество решений";
                        else
                            Result = "Нет решений";
                    }
                    else
                    {
                        double solution = -b / a;
                        Result = $"x = {solution:F2}";
                    }
                }
                else Result = "Ошибка";
            },
            () =>
            {
                return IsAValid && IsBValid;
            });
        }

        private void ValidateA()
        {
            IsAValid = double.TryParse(CoefA,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out _);
        }

        private void ValidateB()
        {
            IsBValid = double.TryParse(CoefB,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out _);
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            if (SolveCommand is Command command) command.ChangeCanExecute();
        }
    }
}
