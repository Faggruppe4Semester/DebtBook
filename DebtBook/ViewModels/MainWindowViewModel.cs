using System.Collections.ObjectModel;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            _debts.Add(new Debt("Morten", -200));
        }

        #region Properties

        private ObservableCollection<Debt> _debts = new ObservableCollection<Debt>();
        public ObservableCollection<Debt> Debts
        {
            get => _debts;
            set => SetProperty(ref _debts, value);

        }
        #endregion
    }

}