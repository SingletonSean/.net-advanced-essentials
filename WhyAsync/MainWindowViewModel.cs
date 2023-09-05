using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Threading.Tasks;

namespace WhyAsync
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly CatFactsQuery _catFactsQuery;

        private readonly ObservableCollection<string> _catFactListing1;
        public IEnumerable<string> CatFactListing1 => _catFactListing1;

        private readonly ObservableCollection<string> _catFactListing2;
        public IEnumerable<string> CatFactListing2 => _catFactListing2;

        [ObservableProperty]
        private bool _isLoadingListing1;

        [ObservableProperty]
        private bool _isLoadingListing2;

        public bool CanLoadCatFacts => !IsLoadingListing1 && !IsLoadingListing2;

        public MainWindowViewModel()
        {
            _catFactsQuery = new CatFactsQuery();

            _catFactListing1 = new ObservableCollection<string>();
            _catFactListing2 = new ObservableCollection<string>();

            PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        [RelayCommand]
        private void LoadCatFacts()
        {
            LoadCatFactListing1Command.Execute(null);
            LoadCatFactListing2Command.Execute(null);
        }

        [RelayCommand]
        private void LoadCatFactListing1()
        {
            IsLoadingListing1 = true;
            _catFactListing1.Clear();

            IEnumerable<CatFact> catFacts = Task.Run(() => _catFactsQuery.Execute(5000)).GetAwaiter().GetResult();
            foreach (CatFact c in catFacts)
            {
                _catFactListing1.Add(c.Content);
            }

            IsLoadingListing1 = false;
        }

        [RelayCommand]
        private void LoadCatFactListing2()
        {
            IsLoadingListing2 = true;
            _catFactListing2.Clear();

            IEnumerable<CatFact> catFacts = Task.Run(() => _catFactsQuery.Execute(10000)).GetAwaiter().GetResult();
            foreach (CatFact c in catFacts)
            {
                _catFactListing2.Add(c.Content);
            }

            IsLoadingListing2 = false;
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Wish there was a cleaner way to do this with MVVM toolkit?
            if (e.PropertyName == nameof(IsLoadingListing1) || e.PropertyName == nameof(IsLoadingListing2))
            {
                OnPropertyChanged(nameof(CanLoadCatFacts));
            }
        }
    }
}
