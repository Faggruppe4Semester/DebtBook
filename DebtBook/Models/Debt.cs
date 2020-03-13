using System;
using System.Collections.ObjectModel;
using System.Data;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Debt : BindableBase
    {
        public Debt()
        {
            
        }
        public Debt(string name, int amount)
        {
            Name = name;
            Amount = amount;
            Entries.Add(new Entry(DateTime.Today, amount));
        }
        private string _name;
        private int _amount;

        public Debt Clone()
        {
            return this.MemberwiseClone() as Debt;
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public int Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);

        }
        
        ObservableCollection<Entry> _entries = new ObservableCollection<Entry>();
        public ObservableCollection<Entry> Entries
        {
            get => _entries;
            set => SetProperty(ref _entries, value);

        }
    }
}