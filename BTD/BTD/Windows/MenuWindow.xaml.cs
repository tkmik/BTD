using BTDService.Services.Users;
using MaterialDesignThemes.Wpf;
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

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IUserService _userService;
        public MenuWindow()
        {
            InitializeComponent();
            _userService = new UserService();            
            DataGrid.ItemsSource = _userService.GetAllUsers();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.CloseApp();
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                ExpandIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowCollapseAll;
                WindowState = WindowState.Maximized;
            }
            else
            {
                ExpandIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowExpandAll;
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }        

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (CheckMode.IsChecked.HasValue == true)
        //    {
        //        FirstColorLine.Color = (Color)ColorConverter.ConvertFromString("#2c3d55");
        //        SecondColorLine.Color = (Color)ColorConverter.ConvertFromString("#536271");

        //       // SearchTextBox.Text = Resources["Light"].ToString();
        //    }
        //    else
        //    {
        //        FirstColorLine.Color = (Color)ColorConverter.ConvertFromString("#e0fbfc");
        //        SecondColorLine.Color = (Color)ColorConverter.ConvertFromString("#98c1d9");
        //    }
        //}
    }
}
