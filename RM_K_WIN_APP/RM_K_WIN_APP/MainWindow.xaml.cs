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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "TypePage":
                    usc = new UC_CreateType();
                    GridMain.Children.Add(usc);
                    break;
                case "StatusPage":
                    usc = new UC_CreateStatus();
                    GridMain.Children.Add(usc);
                    break;
                case "TagRegistartionPage":
                    usc = new UC_CreateTags();
                    GridMain.Children.Add(usc);
                    break;
                case "ResourceAddPage":
                    usc = new UC_CreateResource();
                    GridMain.Children.Add(usc);
                    break;
                case "TagValuePage":
                    usc = new UC_CreateTagValue();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void panelClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void panelWindowResize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if(this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Maximized;
            }
        }
    }
}
