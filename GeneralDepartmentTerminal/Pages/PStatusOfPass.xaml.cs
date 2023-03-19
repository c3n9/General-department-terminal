using GeneralDepartmentTerminal.AppWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneralDepartmentTerminal.Pages
{
    /// <summary>
    /// Логика взаимодействия для PStatusOfPass.xaml
    /// </summary>
    public partial class PStatusOfPass : Page
    {
        Employee contextEmployee;
        public PStatusOfPass(Employee employee)
        {
            InitializeComponent();
            contextEmployee = employee;

            //CBStatus.ItemsSource = App.DB.PassStatus.ToList();

            var statuses = App.DB.PassStatus.ToList();
            statuses.Insert(0, new PassStatus() { Name = "Показать всё" });
            CBStatusForFilter.ItemsSource = statuses.ToList();
            CBStatusForFilter.SelectedIndex = 0;

            var departments = App.DB.Department.ToList();
            departments.Insert(0, new Department() { Name = "Показать всё" });
            CBDepartment.ItemsSource = departments.ToList();
            CBDepartment.SelectedIndex = 0;
            Refresh();
        }

        private void Refresh()
        {
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
            var filtred = App.DB.Pass.ToList();
            var selectedDepartment = CBDepartment.SelectedItem as Department;
            var selectedStatus = CBStatusForFilter.SelectedItem as PassStatus;
            if (selectedDepartment != null && selectedDepartment.Id != 0)
                filtred = filtred.Where(f => f.Employee.DepartmentId == selectedDepartment.Id).ToList();
            if (selectedStatus != null && selectedStatus.Id != 0)
                filtred = filtred.Where(f => f.PassStatusId == selectedStatus.Id).ToList();
            DGGuests.ItemsSource = filtred.ToList();
        }

        private void CBStatusForFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void BStatus_Click(object sender, RoutedEventArgs e)
        {
            var selectedGuest = DGGuests.SelectedItem as Pass;
            if(selectedGuest == null)
            {
                MessageBox.Show("Выберите гостя для продолжения");
                return;
            }
            new EditStatusWindow(selectedGuest).ShowDialog();
        }

        //private void CBStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var guest = DGGuests.SelectedItem as Pass;
        //    if (guest == null)
        //    {
        //        MessageBox.Show("Выберите гостя для изменения статуса");
        //        return;
        //    }
        //    guest.PassStatus = CBStatus.SelectedItem as PassStatus;
        //    App.DB.SaveChanges();
        //    Refresh();
        //}
    }
}
