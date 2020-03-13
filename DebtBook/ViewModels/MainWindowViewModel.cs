using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Windows.Input;
using DebtBook.Models;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;
using DebtBook.Views;
using System.Diagnostics;

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
        
        private Debt _currentDebt;

        public Debt CurrentDebt
        {
            get => _currentDebt;
            set => SetProperty(ref _currentDebt, value);
        }
        
        int _currentIndex = -1;
        public int CurrentIndex
        {
            get => _currentIndex;
            set => SetProperty(ref _currentIndex, value);
        }
        
        #endregion

        #region Commands

        private ICommand _addDebtCommand;

        public ICommand AddDebtCommand
        {
            get
            {
                return _addDebtCommand ?? (_addDebtCommand = new DelegateCommand(() =>
                    {
                        var newDebt = new Debt();
                        var vm = new AddDebtViewModel("Add debt", newDebt);
                        var dlg = new AddDebtView {DataContext = vm};
                        if (dlg.ShowDialog() == true)
                        {
                            Debts.Add(newDebt);
                            CurrentDebt = newDebt;
                        }
                    }));
            }
        }


        private ICommand _openEditDebtor;

        public ICommand OpenEditDebtor
        {
            get
            {
                return _openEditDebtor ?? (_openEditDebtor = new DelegateCommand<Debt>(GetDebtExecute));
            }
        }

        private void GetDebtExecute(Debt debtor)
        {
            if(debtor != null)
            {
                var vm = new EditDebtViewModel();
                vm.Debtor = debtor;
                var newView = new EditDebtView() { DataContext = vm };
                newView.ShowDialog();
            }
        }


        #endregion
    }

}