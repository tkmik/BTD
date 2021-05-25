using BTDCore.ViewModels;
using BTDService.Services.db.Cards;
using BTDService.Services.db.Users;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        private bool DataGridAllSize = false;
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
            DataGrid.ItemsSource = _cardService.GetAllDocumentation();
        }

        private void Documentation_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)AllDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetAllDocumentation();
            }
            if ((bool)TechDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetTechDocumentation();
            }
            if ((bool)DesDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetDesDocumentation();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AllDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetAllDocumentation(SearchTextBox.Text);
            }
            if ((bool)TechDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetTechDocumentation(SearchTextBox.Text);
            }
            if ((bool)DesDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = _cardService.GetDesDocumentation(SearchTextBox.Text);
            }
        }

        private void TreeOnButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DataGridAllSize)
            {
                DataGrid.Margin = new Thickness(10);
                DataGridAllSize = true;
            }
            else
            {
                DataGrid.Margin = new Thickness(160,10,10,10);
                DataGridAllSize = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateDocumentationWindow window = new AddUpdateDocumentationWindow();
            window.Show();
            window.Topmost = true;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not null)
            {
                AddUpdateDocumentationWindow window = new AddUpdateDocumentationWindow((Documentation)DataGrid.SelectedItem);
                window.Owner = this;
                window.Show();
                window.Topmost = true;
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Запись не выбрана!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not null)
            {
                _cardService.Delete(_cardService.GetCardByDesignation(((Documentation)DataGrid.SelectedItem).Designation).Id);
            }
            Documentation_Click(sender, e);
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
