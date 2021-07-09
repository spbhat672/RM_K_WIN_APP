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
    public partial class UC_CreateTags : UserControl
    {
        public UC_CreateTags()
        {
            InitializeComponent();
            List<Models.Type> typeList = ServiceRepository.GetTypeList();
            cmBxTagType.ItemsSource = typeList;
            if (typeList.Count > 0)
                this.cmBxTagType.SelectedItem = typeList[0];
            cmBxTagName.ItemsSource = Constants.tagNames;
        }

        private void UC_TagReg_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmBxTagType.SelectedIndex > 0 && this.cmBxTagName.SelectedIndex > 0)
            {
                Models.TagRegistrationModel tag = new Models.TagRegistrationModel();
                Models.Type selectedType = (Models.Type)this.cmBxTagType.SelectedItem;
                tag.TypeName = selectedType.Name;
                tag.TypeId = selectedType.Id;
                tag.TagName = this.cmBxTagName.SelectedValue.ToString();
                tag.TagUOM = this.txtBxTagUOM.Text;
                ServiceRepository.RegisterNewTag(tag);
            }
            else
                MessageBox.Show("Missing Input");
        }

        private void btnCancelEntry_Click(object sender, RoutedEventArgs e)
        {
            this.cmBxTagType.SelectedIndex = 0;
            this.cmBxTagName.SelectedIndex = 0;
            this.txtBxTagUOM.Text = String.Empty;
        }

        private void cmBxTagName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTagType = this.cmBxTagName.SelectedValue.ToString();
            if(Constants.tagUOM.ContainsKey(selectedTagType))
            {
                this.txtBxTagUOM.Text = Constants.tagUOM.FirstOrDefault(x => x.Key == selectedTagType).Value.ToString();
            }
            
        }
    }
}
