using RM_K_WIN_APP.WebMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RM_K_WIN_APP
{
    /// <summary>
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class UC_CreateStatus : UserControl
    {
        public UC_CreateStatus()
        {
            InitializeComponent();
        }

        private void btnAddStatus_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBxStatusId.Text) || String.IsNullOrEmpty(txtBxStatusName.Text))
            {
                MessageBox.Show("Input is null");
            }

            Models.Status statusObj = new Models.Status();
            statusObj.Id = Convert.ToInt32(txtBxStatusId.Text);
            statusObj.Name = txtBxStatusName.Text;

            ServiceRepository.SaveStatus(statusObj);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
