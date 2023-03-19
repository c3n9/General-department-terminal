using GeneralDepartmentTerminal.Model;
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
using System.Windows.Shapes;

namespace GeneralDepartmentTerminal.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        Pass contextGuest;
        public EditStatusWindow(Pass passGuest)
        {
            InitializeComponent();
            contextGuest = passGuest;
            DataContext = contextGuest;
            CBStatus.ItemsSource = App.DB.PassStatus.ToList();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            contextGuest.PassStatus = CBStatus.SelectedItem as PassStatus;
            App.DB.SaveChanges();
            this.DialogResult = true;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
