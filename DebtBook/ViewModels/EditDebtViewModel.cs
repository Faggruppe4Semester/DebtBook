using DebtBook.Models;


namespace DebtBook.ViewModels
{
    public class EditDebtViewModel
    {
        private Debt _debtor;
        public Debt Debtor
        {
            get { return _debtor; }
            set { _debtor = value; }
        }



    }
}