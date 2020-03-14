using System.Xml;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class AddDebtViewModel : BindableBase
    {
        public AddDebtViewModel()
        {
            
        }
        public AddDebtViewModel(string title, Debt debt)
        {
            Title = title;
            CurrentDebt = debt;
        }
        #region Properties
        
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        
        private Debt _currentDebt;
        public Debt CurrentDebt
        {
            get => _currentDebt;
            set => SetProperty(ref _currentDebt, value);
        }

        private bool _isValid;
        
        public bool IsValid
        {
            get
            {
                _isValid = true;
                if (string.IsNullOrWhiteSpace(CurrentDebt.Name))
                    _isValid = false;
                return _isValid;
            }
            set => SetProperty(ref _isValid, value);
        }

        #endregion
    }
}