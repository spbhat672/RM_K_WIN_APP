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
    /// Interaction logic for UC_CreateType.xaml
    /// </summary>
    public partial class UC_CreateType : UserControl
    {
        public UC_CreateType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBxTypeId.Text) || String.IsNullOrEmpty(txtBxTypeName.Text))
            {
                MessageBox.Show("Input is null");
            }

            Models.Type typeObj = new Models.Type();
            typeObj.Id = Convert.ToInt32(txtBxTypeId.Text);
            typeObj.Name = txtBxTypeName.Text;

            ServiceRepository.SaveType(typeObj);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
