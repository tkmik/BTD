using BTDCore.Models;
using BTDService.Services.Crypto;
using BTDService.Services.Validation;
using BTDService.Services.db.EventsLogs;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using BTDService.Services.db.Users;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        internal static User CurrentUser;

        private readonly IUserService _userService;
        private readonly IEventsLogService _eventsLogService;
        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            _eventsLogService = new EventsLogService();
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

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ICrypto crypt = new CryptoService();
            ValidationUser validation = new ValidationUser();
            switch (await validation.ValidationUserByPasswordAsync(
                UsernameTextBox.Text,
                crypt.Encrypt(UsernamePasswordBox.Password)))
            {
                case ValidationType.Login:
                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                    CurrentUser = await _userService.GetUserByLoginAsync(UsernameTextBox.Text);
                    await _eventsLogService.AddAsync(new EventLog 
                    {
                        UserId = CurrentUser.Id,
                        TableId = default,
                        SystemEventId = (int)BTDSystemEvents.EnterIntoSystem,
                        DateOfEvent = DateTime.Now
                    });
                    Close();
                    //MessageBox.Show("Login");
                    break;
                case ValidationType.LoginError:
                case ValidationType.PasswordError:
                default:
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Логин или пароль неверный!");
                    break;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
