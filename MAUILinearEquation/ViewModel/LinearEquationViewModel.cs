using MAUILinearEquation.Classes;
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
                    //ValidateA();
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
                    //ValidateB();
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
        //public bool IsAValid
        //{
        //    get => data.IsValidA;
        //    set
        //    {
        //        if (data.IsValidA != value)
        //        {
        //            data.IsValidA = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public bool IsBValid
        //{
        //    get => data.IsValidB;
        //    set
        //    {
        //        if (data.IsValidB != value)
        //        {
        //            data.IsValidB = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public LinearEquationViewModel()
        {
            SolveCommand = new Command(() =>
            {
                double a, b;
                if (
                    Double.TryParse(CoefA, out a) &&
                    Double.TryParse(CoefB, out b))
                {
                    var (root, count) = Classes.LinearEquationSolver.Solve(a, b);
                    // Логика решения линейного уравнения
                    switch (count)
                    {
                        case 0:
                            Result = "Нет решений";
                            break;
                        case 1:
                            Result = $"x = {root:F10}";
                            break;
                        case 2:
                            Result = "Бесконечное множество решений";
                            break;
                        default:
                            Result = "Ошибка";
                            break;
                    }
                }
            },
            () =>
            {
                //return IsAValid && IsBValid;
                return 
                    Double.TryParse(CoefA, out _) &&
                    Double.TryParse(CoefB, out _);
            });
        }

        //private void ValidateA()
        //{
        //    IsAValid = double.TryParse(CoefA,
        //        NumberStyles.Any,
        //        CultureInfo.InvariantCulture,
        //        out _);
        //}

        //private void ValidateB()
        //{
        //    IsBValid = double.TryParse(CoefB,
        //        NumberStyles.Any,
        //        CultureInfo.InvariantCulture,
        //        out _);
        //}
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            if (SolveCommand is Command command) command.ChangeCanExecute();
            //((Command)SolveCommand).ChangeCanExecute();
        }
    }
}
