using RM_K_WIN_APP.Models;
using RM_K_WIN_APP.Utils;
using RM_K_WIN_APP.WebMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using System.Windows.Shapes;

namespace RM_K_WIN_APP
{
    /// <summary>
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UC_CreateTags : System.Windows.Controls.UserControl
    {
        public UC_CreateTags()
        {
            InitializeComponent();
            List<Models.ResourceModel> resourceList = ServiceRepository.GetResourceDetails();
            resourceList = resourceList.GroupBy(x => x.ResourceId).Select(g => g.First()).ToList();
            cmBxResource.ItemsSource = resourceList;
            if (resourceList.Count > 0)
                this.cmBxResource.SelectedItem = resourceList[0];
            cmBxTagName.ItemsSource = ServiceRepository.GetTagNamesDetails();
        }

        private void UC_TagReg_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmBxResource.SelectedIndex > 0 && this.cmBxTagName.SelectedIndex > 0)
            {
                Models.TagRegistrationModel tag = new Models.TagRegistrationModel();
                Models.ResourceModel selectedItem = (Models.ResourceModel)this.cmBxResource.SelectedItem;
                tag.TypeName = selectedItem.TypeName;
                tag.TypeId = selectedItem.TypeID;
                tag.TagName = this.cmBxTagName.SelectedValue.ToString();
                tag.ResourceId = selectedItem.ResourceId;
                tag.ResourceName = selectedItem.ResourceName;
                tag.TagUOM = this.txtBxTagUOM.Text;
                ServiceRepository.RegisterNewTag(tag);
            }
            else
                System.Windows.MessageBox.Show("Missing INput");
        }

        private void btnCancelEntry_Click(object sender, RoutedEventArgs e)
        {
            this.cmBxResource.SelectedIndex = 0;
            this.cmBxTagName.SelectedIndex = 0;
            this.txtBxTagUOM.Text = String.Empty;
        }

        private void cmBxTagName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTagType = this.cmBxTagName.SelectedValue.ToString();
            List<Tag> tagNamesList = ServiceRepository.GetTagNamesDetails();
            //string res = this.cmBxResource.Text
            var uomObj = tagNamesList.FirstOrDefault(x => x.TagName == selectedTagType);
            this.txtBxTagUOM.Text = uomObj.TagUOM;
        }
    }
}
