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
    /// Interaction logic for UC_CreateResource.xaml
    /// </summary>
    public partial class UC_CreateResource : UserControl
    {
        public UC_CreateResource()
        {
            InitializeComponent();
            List<Models.Type> typeList = ServiceRepository.GetTypeList();
            cmBxTypeName.ItemsSource = typeList;
            if (typeList.Count > 0)
                this.cmBxTypeName.SelectedItem = typeList[0];
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddResource_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmBxTypeName.SelectedIndex == 0 || String.IsNullOrEmpty(this.txtBxResourceId.Text) || String.IsNullOrEmpty(this.txtBxResourceName.Text))
            {
                MessageBox.Show("Give proper input");
                return;
            }
            if(ServiceRepository.IsResourceExist(Convert.ToInt64(this.txtBxResourceId.Text)))
            {
                MessageBox.Show("this resource is already registered");
                return;
            }
            Models.ResourceModel resource = new Models.ResourceModel();
            resource.ResourceId = Convert.ToInt64(this.txtBxResourceId.Text);
            resource.ResourceName = this.txtBxResourceName.Text;
            Models.Type typeObj = (Models.Type)this.cmBxTypeName.SelectedItem;
            resource.TypeID = typeObj.Id;
            resource.TypeName = typeObj.Name;
            ServiceRepository.AddResource(resource);
        }
    }
}
