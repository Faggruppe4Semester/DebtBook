using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;


namespace DebtBook.ViewModels
{
    public class EditDebtViewModel : BindableBase
    {
        public EditDebtViewModel()
        {
            
        }

        public EditDebtViewModel(string title, Debt debtor)
        {
            Title = title;
            Debtor = debtor;
            Entries = Debtor.Entries;
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private Debt _debtor;
        public Debt Debtor
        {
            get => _debtor;
            set => SetProperty(ref _debtor, value);
        }

       ObservableCollection<Entry> entries;

        public ObservableCollection<Entry> Entries
        {
            get => entries;
            set => SetProperty(ref entries, value);
        }

        private int amount;

        public int Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        private ICommand _addEntryCommand;

        public ICommand AddEntryCommand
        {
            get { return _addEntryCommand ?? (_addEntryCommand = new DelegateCommand(() =>
            {
                Entries.Add(new Entry(DateTime.Today.ToLongDateString(), Amount));
            })); }
        }
    }
}