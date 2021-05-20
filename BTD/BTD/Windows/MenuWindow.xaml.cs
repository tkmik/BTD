using BTDService.Services.db.Users;
using BTDService.Services.db.Cards;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using BTDCore.Models;
using System.Collections.Generic;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        public MenuWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            _cardService = new CardService();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _userService.GetAllUsersDetails();        
        }

        private void Documentation_Click(object sender, RoutedEventArgs e)
        {
            
            if ((bool)AllDocumentation.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetAllDocumnetation();
            }
            if ((bool)TechDocumentation.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetTechDocumnetation();
            }
            if ((bool)DesDocumentation.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetDesDocumnetation();
            }
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
