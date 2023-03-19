using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneralDepartmentTerminal.Pages
{
    /// <summary>
    /// Логика взаимодействия для PLogin.xaml
    /// </summary>
    public partial class PLogin : Page
    {
        public PLogin()
        {
            InitializeComponent();
            Refresh();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.DB.Employee.FirstOrDefault(m => m.Code == TBCodeEmployee.Text);
            if(employee == null || employee.DepartmentId != 6) 
            {
                MessageBox.Show("Неверный код");
                return;
            }
            NavigationService.Navigate(new PStatusOfPass(employee));
        }

        private void Refresh()
        {
            App.MainWindowInstance.BBack.Visibility= Visibility.Collapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
