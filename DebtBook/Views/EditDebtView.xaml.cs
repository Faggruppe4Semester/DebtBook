using System.Windows.Controls;
using System.Windows;
using DebtBook.ViewModels;

namespace DebtBook.Views
{
    public partial class EditDebtView : Window
    {
        public EditDebtView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as EditDebtViewModel;
            DialogResult = true;
           
        }
    }
}