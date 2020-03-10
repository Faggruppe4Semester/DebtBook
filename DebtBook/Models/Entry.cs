using System;
using System.Data;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Entry : BindableBase
    {
        public Entry(DateTime date, int amount)
        {
            Date = date;
            Amount = amount;
        }
        private DateTime _date;
        private int _amount;

        public DateTime Date
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