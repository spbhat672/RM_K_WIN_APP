using RM_K_WIN_APP.Models;
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
using System.Windows.Shapes;

namespace RM_K_WIN_APP
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnAddTagNames_Click(object sender, RoutedEventArgs e)
        {
            String tagName = this.txtBxTagName.Text;
            String tagUOM = this.txtBxTagUOM.Text;
            if (String.IsNullOrEmpty(tagName) || String.IsNullOrEmpty(tagUOM))
            {
                MessageBox.Show("Input is Null");
                return;
            }

            if (ServiceRepository.IsThereTagEntry(tagName))
            {
                MessageBox.Show("This tag Name already exists");
                return;
            }

            Tag tagNameModel = new Tag();
            tagNameModel.TagName = tagName;
            tagNameModel.TagUOM = tagUOM;
            ServiceRepository.SaveTagName(tagNameModel);

        }
    }
}
