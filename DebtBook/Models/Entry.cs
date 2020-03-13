using System;
using System.Data;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Entry : BindableBase
    {
        public Entry() { }
        public Entry(string date, int amount)
        {
            Date = date;
            Amount = amount;
        }
        private string _date;
        private int _amount;

        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public int Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);

        }
    }
}