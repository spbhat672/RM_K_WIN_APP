using Microsoft.Win32;
using RM_K_WIN_APP.Models;
using RM_K_WIN_APP.Utils;
using RM_K_WIN_APP.WebMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
    /// Interaction logic for UC_CreateTagValue.xaml
    /// </summary>
    public partial class UC_CreateTagValue : System.Windows.Controls.UserControl
    {
        public UC_CreateTagValue()
        {
            InitializeComponent();
            List<Models.ResourceModel> resourceList = ServiceRepository.GetResourceDetails();
            this.cmBxResourceName.ItemsSource = resourceList;
            if (resourceList.Count > 0)
                this.cmBxResourceName.SelectedItem = resourceList[0];
        }

        private void btnAddTagValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.cmBxResourceName.SelectedIndex == 0 || this.cmBxTagName.SelectedIndex == 0)
                {
                    System.Windows.MessageBox.Show("Invalid Input");
                    return;
                }
                else if(this.Status.IsVisible && this.cmBxStatus.SelectedIndex == 0)
                {
                    System.Windows.MessageBox.Show("Choose one status");
                    return;
                }
                else if(this.Speed.IsVisible && String.IsNullOrEmpty(this.txtBxSpeedValue.Text))
                {
                    System.Windows.MessageBox.Show("Speed value is empty");
                    return;
                }
                else if(this.Position.IsVisible && (this.txtBxPosition.Text.Length < 5) && (this.txtBxPosition.Text.Count(x => x == ',') != 2))
                {
                    System.Windows.MessageBox.Show("Position value is wrong");
                    return;
                }
                else if(this.Orientation.IsVisible && (this.txtBxOrientation.Text.Length < 5) && (this.txtBxOrientation.Text.Count(x => x == ',') != 2))
                {
                    System.Windows.MessageBox.Show("Orientation value is wrong");
                    return;
                }
                ResourceWithValue tagValue = new ResourceWithValue();
                tagValue.ResourceId = Convert.ToInt64(this.cmBxResourceName.SelectedValue.ToString());
                Tag tag = (Tag)this.cmBxTagName.SelectedItem;
                tagValue.TagName = tag.TagName.Replace(tag.TagResourceId + ":- ", "");
                var obj = Constants.tagUOM.FirstOrDefault(x => x.Key == tagValue.TagName);
                tagValue.TagUOM = tagValue.TagName == "Status"? null : obj.Value.ToString();
                tagValue.TagCreationDate = DateTime.Now;
                Tag selectedTag = (Tag)this.cmBxTagName.SelectedItem;
                tagValue.TagId = selectedTag.TagId;
                string tagInputValue = "";
                if (this.Status.IsVisible)
                {
                    Status status = (Status)this.cmBxStatus.SelectedItem;
                    tagInputValue = status.Name;
                }
                else if (this.Position.IsVisible)
                {
                    tagInputValue = this.txtBxPosition.Text;
                }
                else if (this.Orientation.IsVisible)
                {
                    tagInputValue = this.txtBxOrientation.Text;
                }
                else if (this.Speed.IsVisible)
                {
                    tagInputValue = this.txtBxSpeedValue.Text;
                }
                tagValue.TagValue = tagInputValue;

                ServiceRepository.AddTagValue(tagValue);

                this.cmBxResourceName.SelectedIndex = 0;
                this.cmBxTagName.SelectedIndex = 0;
                this.cmBxStatus.SelectedIndex = 0;
                this.txtBxSpeedValue.Text = String.Empty;
                this.txtBxPosition.Text = String.Empty;
                this.txtBxOrientation.Text = String.Empty;
            }
            catch(Exception ex)
            {

            }
        }

        private void cmBxResourceName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResourceModel selectedResource = (ResourceModel)this.cmBxResourceName.SelectedItem;
            List<Tag> tagList = ServiceRepository.GetTagDetails(selectedResource.ResourceId);
            this.cmBxTagName.ItemsSource = tagList;
            if (tagList.Count > 0)
                this.cmBxTagName.SelectedItem = tagList[0];

            this.cmBxStatus.SelectedIndex = 0;
        }

        private void cmBxTagName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.cmBxTagName.SelectedIndex > 0)
            {
                Tag selectedTag = (Tag)cmBxTagName.SelectedItem;
                if (selectedTag.TagName.Contains("Status"))
                {
                    this.cmBxStatus.ItemsSource = ServiceRepository.GetStatusList();
                    this.Status.Visibility = Visibility.Visible;
                    this.Position.Visibility = Visibility.Collapsed;
                    this.Orientation.Visibility = Visibility.Collapsed;
                    this.Speed.Visibility = Visibility.Collapsed;
                }
                else if (selectedTag.TagName.Contains("Position"))
                {
                    this.Position.Visibility = Visibility.Visible;
                    this.Status.Visibility = Visibility.Collapsed;
                    this.Orientation.Visibility = Visibility.Collapsed;
                    this.Speed.Visibility = Visibility.Collapsed;
                }
                else if (selectedTag.TagName.Contains("Orientation"))
                {
                    this.Orientation.Visibility = Visibility.Visible;
                    this.Status.Visibility = Visibility.Collapsed;
                    this.Position.Visibility = Visibility.Collapsed;
                    this.Speed.Visibility = Visibility.Collapsed;
                }
                else if (selectedTag.TagName.Contains("Speed"))
                {
                    this.Speed.Visibility = Visibility.Visible;
                    this.Status.Visibility = Visibility.Collapsed;
                    this.Position.Visibility = Visibility.Collapsed;
                    this.Orientation.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            string fname = "";
            System.Windows.Forms.OpenFileDialog fdlg = new System.Windows.Forms.OpenFileDialog();
            fdlg.Title = "Choose one Tag related Excel file";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }


            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            List<ExcelTagInput> inputValues = new List<ExcelTagInput>();
            int j = 1;
            for (int i = 2; i <= rowCount; i++)
            {
                ExcelTagInput excelTag = new ExcelTagInput();
                excelTag.ResourceId = Convert.ToInt64(xlRange.Cells[i, j].Value);                
                excelTag.TagId = Convert.ToInt64(xlRange[i, j + 1].Value);
                excelTag.TagName = Convert.ToString(xlRange[i, j + 2].Value);
                excelTag.TagValue = Convert.ToString(xlRange[i, j + 3].Value);
                excelTag.TagUOM = Convert.ToString(xlRange.Cells[i, j + 4].Value);
                excelTag.TagCreationDate = Convert.ToDateTime(xlRange[i, j + 5].Value);
                inputValues.Add(excelTag);
            }

            inputValues = inputValues.Where(x => x.ResourceId != 0 && x.TagId != 0).ToList();
            ServiceRepository.RegisterTagValue(inputValues);
            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);


        }
    }
}