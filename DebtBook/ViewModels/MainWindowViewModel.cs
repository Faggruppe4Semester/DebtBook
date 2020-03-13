using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
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

<<<<<<<<< Temporary merge branch 1
        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get => _loadCommand ?? (_loadCommand = new DelegateCommand(LoadHandlerExecute));
        }

        void LoadHandlerExecute()
        {
            var tempDepts = new ObservableCollection<Debt>();

            XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<Debt>));

            try
            {
                TextReader reader = new StreamReader("DeptSave.txt");
                tempDepts = (ObservableCollection<Debt>) x.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to open saved data", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Debts.Clear();
            foreach (var dept in tempDepts)
            {
                Debts.Add(dept);
            }

            CurrentIndex = 0;
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveHandlerExecute));
        }

        void SaveHandlerExecute()
        {
            XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<Debt>));
            TextWriter writer = new StreamWriter("DeptSave.txt");
            x.Serialize(writer,Debts);
            writer.Close();
        }
=========

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

>>>>>>>>> Temporary merge branch 2

        #endregion
    }

}