using System.Windows;
using DebtBook.ViewModels;

namespace DebtBook.Views
{
    public partial class AddDebtView : Window
    {
        public AddDebtView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AddDebtViewModel;
            if (vm.IsValid)
                DialogResult = true;
            else
                MessageBox.Show("Enter values for name and debt amount", "Missing data");
        }
    }
}