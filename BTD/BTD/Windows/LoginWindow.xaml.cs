using BTDService.Services.Crypto;
using BTDService.Services.Validation;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        //private readonly IUserService _userService;
        public LoginWindow()
        {
            InitializeComponent();
            //_userService = new UserService();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.IsKeyboardFocusWithin)
            {
                UsernameTextBox.Text = "";
            }
        }
        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!UsernameTextBox.IsKeyboardFocusWithin
                && String.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username";
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernamePasswordBox.IsKeyboardFocusWithin)
            {
                UsernamePasswordBox.Password = "";
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!UsernamePasswordBox.IsKeyboardFocusWithin
                && String.IsNullOrWhiteSpace(UsernamePasswordBox.Password))
            {
                UsernamePasswordBox.Password = "Password";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ICrypto crypt = new CryptoService();
            ValidationUser validation = new ValidationUser();
            switch (validation.ValidationUserByPassword(
                UsernameTextBox.Text,
                crypt.Encrypt(UsernamePasswordBox.Password)))
            {
                case ValidationType.Login:
                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                    Close();
                    //MessageBox.Show("Login");
                    break;
                case ValidationType.LoginError:
                case ValidationType.PasswordError:
                default:
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Login or password has been wrong!");
                    break;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.CloseApp();
        }
    }
}
