using BTDCore.Models;
using BTDCore.ViewModels;
using BTDService.Services.db.EventsLogs;
using BTDService.Services.db.Role;
using BTDService.Services.db.Tables;
using BTDService.Services.db.Users;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for AddUpdateUserWindow.xaml
    /// </summary>
    public partial class AddUpdateUserWindow : Window
    {
        IRoleService _roleService;
        IUserService _userService;
        IEventsLogService _eventLogService;
        ITableService _tableService;
        public AddUpdateUserWindow(ViewUserDetails user = default)
        {
            _roleService = new RoleService();
            _userService = new UserService();
            _eventLogService = new EventsLogService();
            _tableService = new TableService();
            InitializeComponent();
            if (user is not null)
            {
                var userCapability = _userService.GetUserByLogin(user.Login);
                LoginTextBox.Text = user.Login;
                RoleComboBox.SelectedItem = _roleService.Roles(user.RoleName);
                FirstNameTextBox.Text = user.FirstName;
                LastNameTextBox.Text = user.LastName;
                DateOfBirthDatePicker.Text = user.DateOfBirth.ToString();
                SerialNumberTextBox.Text = user.SerialNumber;
                CreateDocCheckBox.IsChecked = userCapability.UserCapabilities.CanAddInfo;
                EditDocCheckBox.IsChecked = userCapability.UserCapabilities.CanEditInfo;
                DeleteDocCheckBox.IsChecked = userCapability.UserCapabilities.CanDeleteInfo;
                ReportCheckBox.IsChecked = userCapability.UserCapabilities.CanMakeReport;
                CreateUserCheckBox.IsChecked = userCapability.UserCapabilities.CanMakeNewUser;
                EditUserCheckBox.IsChecked = userCapability.UserCapabilities.CanEditUser;
                DeleteUserCheckBox.IsChecked = userCapability.UserCapabilities.CanDeleteUser;
            }
            SaveButton.Click += async (sender, e) =>
            {
                if (!LoginTextBox.Text.Equals("")
                && !PasswordTextBox.Password.Equals("")
                &&!FirstNameTextBox.Text.Equals("")
                &&!LastNameTextBox.Text.Equals("")
                &&!DateOfBirthDatePicker.Text.Equals("")
                &&!SerialNumberTextBox.Text.Equals("")
                &&!(RoleComboBox.SelectedItem is not null))
                {
                    if (user is not null)
                    {
                        User oldUser = await _userService.GetUserByLoginAsync(user.Login);
                        oldUser.Login = LoginTextBox.Text;
                        oldUser.Password = PasswordTextBox.Password;
                        oldUser.RoleId = RoleComboBox.SelectedIndex;
                        oldUser.UserDetails.FirstName = FirstNameTextBox.Text;
                        oldUser.UserDetails.LastName = LastNameTextBox.Text;
                        oldUser.UserDetails.DateOfBirth = Convert.ToDateTime(DateOfBirthDatePicker.Text);
                        oldUser.UserDetails.SerialNumber = SerialNumberTextBox.Text;
                        oldUser.UserCapabilities.CanAddInfo = (bool)CreateDocCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanEditInfo = (bool)EditDocCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanDeleteInfo = (bool)DeleteDocCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanMakeReport = (bool)ReportCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanMakeNewUser = (bool)CreateUserCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanEditUser = (bool)EditUserCheckBox.IsChecked;
                        oldUser.UserCapabilities.CanDeleteUser = (bool)DeleteUserCheckBox.IsChecked;
                        await _userService.UpdateAsync(oldUser);
                        await _eventLogService.AddAsync(new EventLog
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Users),
                            SystemEventId = (int)BTDSystemEvents.Editing,
                            DateOfEvent = DateTime.Now
                        });
                    }
                    else
                    {
                        User newUser = new User();
                        newUser.Login = LoginTextBox.Text;
                        newUser.Password = PasswordTextBox.Password;
                        newUser.RoleId = RoleComboBox.SelectedIndex;
                        newUser.UserDetails.FirstName = FirstNameTextBox.Text;
                        newUser.UserDetails.LastName = LastNameTextBox.Text;
                        newUser.UserDetails.DateOfBirth = Convert.ToDateTime(DateOfBirthDatePicker.Text);
                        newUser.UserDetails.SerialNumber = SerialNumberTextBox.Text;
                        newUser.UserCapabilities.CanAddInfo = (bool)CreateDocCheckBox.IsChecked;
                        newUser.UserCapabilities.CanEditInfo = (bool)EditDocCheckBox.IsChecked;
                        newUser.UserCapabilities.CanDeleteInfo = (bool)DeleteDocCheckBox.IsChecked;
                        newUser.UserCapabilities.CanMakeReport = (bool)ReportCheckBox.IsChecked;
                        newUser.UserCapabilities.CanMakeNewUser = (bool)CreateUserCheckBox.IsChecked;
                        newUser.UserCapabilities.CanEditUser = (bool)EditUserCheckBox.IsChecked;
                        newUser.UserCapabilities.CanDeleteUser = (bool)DeleteUserCheckBox.IsChecked;
                        await _userService.AddAsync(newUser);
                        await _eventLogService.AddAsync(new EventLog
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Users),
                            SystemEventId = (int)BTDSystemEvents.Adding,
                            DateOfEvent = DateTime.Now
                        });
                    }
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные были сохранены!");
                    Close();
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные введены некорректно!");
                }
            };

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
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RoleComboBox.ItemsSource = _roleService.Roles();
        }
    }
}
