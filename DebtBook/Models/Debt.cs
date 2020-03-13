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
            Entries.Add(new Entry("03.03.2020", amount));
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
            set
            {
                TotalAmount = CalcAmount();
                SetProperty(ref _amount, value);
            }
        }

        private int _totalAmount;

        public int TotalAmount
        {
            get => _totalAmount;
            set => SetProperty(ref _totalAmount, value);
        }

        public int CalcAmount()
        {
            int total = 0;
                
            foreach (var e in Entries)
            {
                total += e.Amount;
            }
            return total; 
        }

        ObservableCollection<Entry> _entries = new ObservableCollection<Entry>();
        public ObservableCollection<Entry> Entries
        {
            get => _entries;
            set => SetProperty(ref _entries, value);

        }
    }
}