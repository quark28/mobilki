using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lab1_Team
{
    // ViewModel: то, к чему привязывается экран (как ClockViewModel в задаче 2
    // и KeyPadViewModel в задаче 4)
    public class TeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // ObservableCollection сама сообщает экрану о добавлении элементов,
        // поэтому новый участник появляется в списке без ручного обновления
        public ObservableCollection<Student> Members { get; } = new()
        {
            new Student { FullName = "Лебедев Лев",  Group = "15.27Д-БИ02/24б" },
            new Student { FullName = "Ишназаров Радмир", Group = "15.27Д-БИ02/24б" },
            new Student { FullName = "Гусев Никита", Group = "15.27Д-БИ02/24б" },
            new Student { FullName = "Терзикян Ваагн", Group = "15.27Д-БИ02/24б" }
        };

        string _newName = "";
        public string NewName
        {
            get => _newName;
            set
            {
                if (_newName != value)
                {
                    _newName = value;
                    OnPropertyChanged();
                    // кнопка "Добавить" активна только если имя не пустое
                    ((Command)AddCommand).ChangeCanExecute();
                }
            }
        }

        string _newGroup = "15.27Д-БИ02/24б";
        public string NewGroup
        {
            get => _newGroup;
            set
            {
                if (_newGroup != value)
                {
                    _newGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CountText => $"Участников в команде: {Members.Count}";

        public ICommand AddCommand { get; }

        public TeamViewModel()
        {
            // Command(что сделать, можно ли сделать) — как в задаче 4
            AddCommand = new Command(
                () =>
                {
                    Members.Add(new Student { FullName = NewName, Group = NewGroup });
                    NewName = "";
                    OnPropertyChanged(nameof(CountText));
                },
                () => !string.IsNullOrWhiteSpace(NewName));
        }

        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}