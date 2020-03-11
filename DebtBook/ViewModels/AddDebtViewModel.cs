using System.Xml;
using DebtBook.Models;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class AddDebtViewModel : BindableBase
    {


        #region Properties

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
                if (CurrentDebt.Amount == 0)
                    _isValid = false;
                return _isValid;
            }
            set => SetProperty(ref _isValid, value);
        }

        #endregion
    }
}